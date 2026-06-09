using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private AudioSource som;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DestroyBullets"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Debris"))
        {
            som.Play();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
