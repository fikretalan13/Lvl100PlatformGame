using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    [SerializeField] GameObject hitEffect;

    [HideInInspector] public bool isDead;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this);
        }
    }

    public void PlayerTakeDamage()
    {
        isDead = true;
        AudioManager.instance.PlaySound(1);
        Destroy(gameObject);
        Instantiate(hitEffect, transform.position, Quaternion.identity);
    }
}
