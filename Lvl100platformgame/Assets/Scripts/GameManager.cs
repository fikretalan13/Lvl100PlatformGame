using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameFinished;

    public TextMeshProUGUI timerResult;
    public TextMeshProUGUI teleportAmount;

    [HideInInspector]
    public int teleportCount;

    private void Awake()
    {
       if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
    }
    public void GameFinished()
    {
        isGameFinished=true;
        UIManager.instance.FinishPanel();
        teleportAmount.text=teleportCount.ToString();
        teleportCount=0;
    }
}
