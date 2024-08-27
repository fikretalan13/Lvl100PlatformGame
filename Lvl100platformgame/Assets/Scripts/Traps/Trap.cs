using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth.instance.PlayerTakeDamage();
        }

        if (other.CompareTag("FallingPlatform"))
        {
            Destroy(other.gameObject);

        }
    }
}
