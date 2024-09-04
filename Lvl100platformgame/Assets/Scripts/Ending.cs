using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField] GameObject endingAnim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player.instance.playerSpeed = 0;
            endingAnim.SetActive(true);
            StartCoroutine(EndingDelay());
        }
    }

    IEnumerator EndingDelay()
    {
        yield return new WaitForSeconds(4);
        GameManager.instance.GameFinished();

    }
}
