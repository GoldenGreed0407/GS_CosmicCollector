using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Canvas[] canvas;
    [SerializeField] private Button buttonPause;
    [SerializeField] private Button buttonResume;
    [SerializeField] private Button buttonReset;
    [SerializeField] private Button buttonClose;
    [SerializeField] private Slider sliderVolume;
    [SerializeField] private Button buttonResetGameOver;
    [SerializeField] private Button buttonCloseGameOver;
    [SerializeField] private Button buttonResetWin;
    [SerializeField] private Button buttonCloseWin;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        buttonPause.onClick.AddListener(ShowWindow);
        buttonResume.onClick.AddListener(HideWindow);
        buttonClose.onClick.AddListener(CloseGame);
        buttonReset.onClick.AddListener(ResetGame);
        buttonResetGameOver.onClick.AddListener(ResetGame);
        buttonResetWin.onClick.AddListener(ResetGame);
        buttonCloseGameOver.onClick.AddListener(CloseGame);
        buttonCloseWin.onClick.AddListener(CloseGame);
        HideWindow();
        HideWindowGameOver();
        HideWindowWin();
    }

    private void Update()
    {
        GameObject.Find("MusicManager").GetComponent<MusicManager>().Volume(sliderVolume.value);

        if(CanvasStats.shipLife <= 0 ||  CanvasStats.StationLife <= 0)
        {
            audioSource.Play();
            ShowGameOver();
        }
        if(CanvasStats.deposited >= 20)
        {
            ShowWin();
        }

        if (Input.GetButtonDown("Cancel"))
        {
            ShowWindow();
        }
    }

    private void ResetGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void CloseGame()
    {
        SceneManager.LoadScene("StartScene");
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
    private void HideWindowGameOver()
    {
        canvas[2].enabled = false;
        Resume();
    }

    private void ShowGameOver()
    {
        canvas[2].enabled = true;
        Pause();
    }

    private void ShowWin()
    {
        canvas[3].enabled = true;
        Pause();
    }
    private void HideWindowWin()
    {
        canvas[3].enabled = false;
        Resume();
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
