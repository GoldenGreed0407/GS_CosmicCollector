using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] public float volume;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        audioSource.volume = volume;
    }

    public void Volume(float v)
    {
        volume = v;
    }

}
