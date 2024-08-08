using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
    [SerializeField] GameObject teleportCollider;

    private void Start() {
        teleportCollider.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           Destroy(gameObject);
            teleportCollider.SetActive(true);
        }
    }
}
