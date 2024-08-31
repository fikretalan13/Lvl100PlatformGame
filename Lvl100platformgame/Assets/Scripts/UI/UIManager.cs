using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject settingsPanel;
    public int currentSceneIndex;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Bu Canvas'ı sahne geçişlerinde koru
        }
    }
    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
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
        Time.timeScale = 1;
    }
    public void ReturnMenu()
    {
       
        SceneManager.LoadScene(0);
        pausePanel.SetActive(false);
        currentSceneIndex = 1;
        Time.timeScale = 1;
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


}
