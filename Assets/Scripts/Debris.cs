using UnityEngine;

public class Debris : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector2 targetPosition;

    void Start()
    {
        targetPosition = GameObject.FindGameObjectWithTag("SpaceStation").transform.position;
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
