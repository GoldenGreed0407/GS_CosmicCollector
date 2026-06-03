using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Canvas[] canvas;
    [SerializeField] private Button buttonPause;
    [SerializeField] private Button buttonResume;
    [SerializeField] private Button buttonReset;
    [SerializeField] private Button buttonResetGameOver;
    [SerializeField] private Button buttonResetWin;
    [SerializeField] private Button buttonClose;    
    [SerializeField] private Button buttonCloseGameOver;    
    [SerializeField] private Button buttonCloseWin;
    [SerializeField] private Slider sliderVolume;
    [SerializeField] private Button retryGame;
    [SerializeField] private Button playAgain;
    private GameObject canvasMain;

    private void Start()
    {
        canvasMain = GameObject.Find("CanvasMain");
        buttonPause.onClick.AddListener(ShowWindow);
        buttonResume.onClick.AddListener(HideWindow);
        buttonClose.onClick.AddListener(CloseGame);
        buttonReset.onClick.AddListener(ResetGame);
        buttonResetGameOver.onClick.AddListener(ResetGame);
        buttonResetWin.onClick.AddListener(ResetGame);
        retryGame.onClick.AddListener(ResetGame);
        playAgain.onClick.AddListener(ResetGame);
        HideWindow();
        HideWindowGameOver();
        HideWindowWin();
    }

    private void Update()
    {
        GameObject.Find("MusicManager").GetComponent<MusicManager>().Volume(sliderVolume.value);

        if(CanvasStats.shipLife <= 0 ||  CanvasStats.StationLife <= 0)
        {
            ShowGameOver();
        }
        if(CanvasStats.deposited >= 20)
        {
            ShowWin();
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
