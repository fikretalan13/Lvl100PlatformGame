using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_GATE : MonoBehaviour
{
    [SerializeField] Transform gatePos;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = gatePos.position;
        }
    }

}
