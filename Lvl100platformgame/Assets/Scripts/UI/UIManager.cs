using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject finishPanel;

    public TextMeshProUGUI whichLevel;
    public int currentSceneIndex;

    private void Awake()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            if (currentSceneName != "Main Menu")
            {
                DontDestroyOnLoad(gameObject);
            }
           
        }
    }
    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        whichLevel.text=1.ToString();
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        finishPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ReturnGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void ReStartGame()
    {
        SceneManager.LoadScene(currentSceneIndex);
        pausePanel.SetActive(false);
        finishPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void ReturnMenu()
    {
        Stopwatch.instance.StopTimer();
        whichLevel.text=1.ToString();
        SceneManager.LoadScene(0);
        pausePanel.SetActive(false);
        currentSceneIndex = 1;
        Time.timeScale = 1;
    }

    public void FinishReturnMenu()
    {
        whichLevel.text=1.ToString();
        SceneManager.LoadScene(0);
        AudioManager.instance.ChangeMusicAgain();
        pausePanel.SetActive(false);
        finishPanel.SetActive(false);
        currentSceneIndex = 1;
        Time.timeScale = 1;
        GameManager.instance.isGameFinished=false;
        //Stopwatch.instance.timerText.text=0.ToString();
    }



    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("cikis yapildi");
    }

    public void SettingsPanelOn()
    {
        settingsPanel.SetActive(true);
    }
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void FinishPanel()
    {
      finishPanel.SetActive(true);
    }


}
