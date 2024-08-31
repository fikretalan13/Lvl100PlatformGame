using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel;
    public GameObject eventSystem;
    private void Start()
    {
        settingsPanel.SetActive(false);
    }
    public void StartBTN()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingsBTN()
    {
        settingsPanel.SetActive(true);
    }
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Çıkış Yapıldı");
    }
}
