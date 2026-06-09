using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;


public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private float velocidade;
    [SerializeField] private Vector3 StartPosition;
    [SerializeField] private AudioSource[] som;

    [Header("Weapons")]
    [SerializeField] private GameObject DMGBullet;
    [SerializeField] private GameObject EXTBullet;
    [SerializeField] private int Ammo = 20;
    [SerializeField] private int MaxAmmo = 20;
    [SerializeField] private Transform WeaponPosition;
    [SerializeField] private int activeWeapon;
    [SerializeField] private Text TypeAmmo;

    [SerializeField] private GameObject canvasMain;
    Rigidbody rb;
    Transform Thirdcamera;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Thirdcamera = Camera.main.transform;
        transform.position = StartPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 moveInputs = new Vector3(x, rb.linearVelocity.y, z);

        // Calcula movimento baseado na direção forward
        Vector3 moveFinal = transform.forward * moveInputs.magnitude * velocidade;

        // Aplica velocidade no Rigidbody
        rb.linearVelocity = new Vector3(moveFinal.x, rb.linearVelocity.y, moveFinal.z);

        var frente = Thirdcamera.transform.TransformDirection(Vector3.forward);
        frente.y = 0;

        var direita = Thirdcamera.transform.TransformDirection(Vector3.right);

        Vector3 direcao = x * direita + z * frente;

        if ((x != 0 || z != 0) && direcao.magnitude > 0.1f)
        {
            Quaternion rotacaoLivre = Quaternion.LookRotation(direcao.normalized, transform.up);
            transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.Euler(new Vector3(transform.eulerAngles.x, rotacaoLivre.eulerAngles.y, transform.eulerAngles.z)),
            10 * Time.deltaTime);
        }
    }

    void Attack()
    {
        if(Input.GetButtonDown("Fire3") && activeWeapon == 2)
        {
            activeWeapon = 1;
            TypeAmmo.color = Color.red;
        }
        else if(Input.GetButtonDown("Fire3") && activeWeapon == 1)
        {
            activeWeapon = 2;
            TypeAmmo.color = Color.yellow;
        }
        if (Input.GetButtonDown("Jump") && activeWeapon == 1 && Ammo > 0)
        {
            som[0].Play();
            Ammo--;
            CanvasStats.Ammo--;
            canvasMain.GetComponent<CanvasMain>().UpdateAmmo();
            Instantiate(DMGBullet, WeaponPosition.position, Quaternion.Euler(new Vector3(transform.eulerAngles.x,
                transform.eulerAngles.y, transform.eulerAngles.z)));
        } 
        else if (Input.GetButtonDown("Jump") && activeWeapon == 2 && Ammo > 0)
        {
            som[0].Play();
            Ammo--;
            CanvasStats.Ammo--;
            canvasMain.GetComponent<CanvasMain>().UpdateAmmo();
            Instantiate(EXTBullet, WeaponPosition.position, Quaternion.Euler(new Vector3(transform.eulerAngles.x, 
                transform.eulerAngles.y, transform.eulerAngles.z)));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DestroyBullets"))
        {
            transform.position = StartPosition;
        }
        if (other.CompareTag("Debris"))
        {
            som[3].Play();
            Destroy(other.gameObject);
            CanvasStats.shipLife--;
            canvasMain.GetComponent<CanvasMain>().UpdateShipLife();
            transform.position = StartPosition;
        }
        if (other.CompareTag("Meteor"))
        {
            som[3].Play();
            CanvasStats.shipLife--;
            canvasMain.GetComponent<CanvasMain>().UpdateShipLife();
            transform.position = StartPosition;
        }
        if (other.CompareTag("Valuable"))
        {
            som[1].Play();
            Destroy(other.gameObject);
            CanvasStats.collectable++;
            canvasMain.GetComponent<CanvasMain>().UpdateCollectable();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "SpaceStation")
        {
            som[2].Play();
            Ammo = MaxAmmo;
            CanvasStats.Ammo = Ammo;
            canvasMain.GetComponent<CanvasMain>().UpdateAmmo();
            CanvasStats.deposited += CanvasStats.collectable;
            canvasMain.GetComponent <CanvasMain>().UpdateDeposited();
            CanvasStats.collectable-= CanvasStats.collectable;
            canvasMain.GetComponent<CanvasMain>().UpdateCollectable();
        }
    }
}
