using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    Animator anim;
    [SerializeField] GameObject kapak;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball") || other.CompareTag("Box"))
        {
            anim.SetBool("Btn_On", true);
            kapak.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ball") || other.CompareTag("Box"))
        {
            anim.SetBool("Btn_On", false);
        }
    }
}
