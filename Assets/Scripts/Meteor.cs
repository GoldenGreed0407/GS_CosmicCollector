using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour
{
    [SerializeField] private GameObject[] debris;
    [SerializeField] private GameObject[] gold;

    void Start()
    {
        StartCoroutine(spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawner()
    {
        yield return new WaitForSeconds(5);
        spawnDebris();
        StartCoroutine(spawner());
    }


    private void spawnDebris()
    {
        Instantiate(debris[Random.Range(0, 3)], new Vector3(-21, 0.5f, Random.Range(32, 41)), Quaternion.identity);
        Instantiate(debris[Random.Range(0, 3)], new Vector3(21, 0.5f, Random.Range(32, 41)), Quaternion.identity);
    }
    private void damage()
    {
        float times = Random.Range(1, 3);
        for(int i = 0; i < times; i++)
        {
            Instantiate(debris[Random.Range(0, 3)], new Vector3(-21, 0.5f, Random.Range(32, 41)), Quaternion.identity);
            Instantiate(debris[Random.Range(0, 3)], new Vector3(21, 0.5f, Random.Range(32, 41)), Quaternion.identity);
        }
    }

    private void extract()
    {
        float side = Random.Range(1, 3);
        if(side <= 1)
        {
            Instantiate(debris[Random.Range(0, 3)], new Vector3(-21, 0.9f, Random.Range(32, 41)), Quaternion.identity);
        }
        else
        {
            Instantiate(debris[Random.Range(0, 3)], new Vector3(21, 0.9f, Random.Range(32, 41)), Quaternion.identity);
        }
        float amount = Random.Range(1, 3);
        for(int i = 0;i < amount; i++)
        {
            Instantiate(gold[Random.Range(0,3)], new Vector3(Random.Range(-10,11), 0.9f, 20), Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletDMG"))
        {
            Destroy(other.gameObject);
            damage();
        }
        if (other.gameObject.CompareTag("BulletEXT"))
        {
            Destroy(other.gameObject);
            extract();
        }
    }
}
