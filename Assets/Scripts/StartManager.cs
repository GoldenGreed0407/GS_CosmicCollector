using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [SerializeField] private Canvas[] canvas;

    [SerializeField] private Button buttonPause;
    [SerializeField] private Button buttonResume;
    [SerializeField] private Slider sliderVolume;

    private void Start()
    {

        buttonPause.onClick.AddListener(ShowWindow);
        buttonResume.onClick.AddListener(HideWindow);
        HideWindow();
    }
    private void Update()
    {
        GameObject.Find("MusicManager").GetComponent<MusicManager>().Volume(sliderVolume.value);
    }

    private void HideWindow()
    {
        canvas[1].enabled = false;
        Resume();
    }

    private void ShowWindow()
    {
        canvas[1].enabled = true;
        Pause();
    }

    void Pause()
    {
        Time.timeScale = 0.0f;
    }

    void Resume()
    {
        Time.timeScale = 1.0f;
    }
}
