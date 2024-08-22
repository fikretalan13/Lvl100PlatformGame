using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFallingTrap : MonoBehaviour
{
    [SerializeField] Rigidbody2D fallingTrapRb;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            fallingTrapRb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
