using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           int randomLevel= Random.Range(1,100);
           UIManager.instance.currentSceneIndex=randomLevel;
           SceneManager.LoadScene(randomLevel);
        }
    }
}
