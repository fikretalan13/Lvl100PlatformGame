using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;

    public float dropDelay;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("DropPlatform", dropDelay);
        }
    }

    void DropPlatform()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, 10);
    }
}
