using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
     private static EventSystem instance;

    void Awake()
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

    private void Start()
    {
        // Eğer sahnede bir EventSystem yoksa, mevcut olanı koru
        if (FindObjectsOfType<EventSystem>().Length > 1)
        {
            foreach (var es in FindObjectsOfType<EventSystem>())
            {
                if (es != instance.GetComponent<EventSystem>())
                {
                    Destroy(es.gameObject);
                }
            }
        }
    }
}
