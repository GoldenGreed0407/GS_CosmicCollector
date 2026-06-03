using UnityEngine;
using System.Collections;

public class SpaceStation : MonoBehaviour
{
    private int damage;
    private GameObject canvasMain;
    void Start()
    {
        canvasMain = GameObject.Find("CanvasMain");
        StartCoroutine(Damage(damage));
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Debris") || other.CompareTag("BulletDMG"))
        {
            Destroy(other.gameObject);
            CanvasStats.StationLife -= 5;
            damage++;
            canvasMain.GetComponent<CanvasMain>().UpdateStationLife();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            damage = 0;
        }
    }
    IEnumerator Damage(int d)
    {
        yield return new WaitForSeconds(1.0f);
        CanvasStats.StationLife -= d;
        canvasMain.GetComponent<CanvasMain>().UpdateStationLife();
        StartCoroutine(Damage(d));
    }
}
