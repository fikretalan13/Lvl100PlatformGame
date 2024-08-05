using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    int maxHealth = 3;
    public int currentHealth;

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
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void PlayerTakeDamage()
    {
        currentHealth--;
        if (currentHealth < 1)
        {
            currentHealth = 0;
            isDead = true;
        }
    }
}
