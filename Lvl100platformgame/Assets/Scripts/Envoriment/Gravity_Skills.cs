using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Skills : MonoBehaviour
{
    int pressCount;
    Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.isGravitySkillsTaken = true;
            Destroy(gameObject);
        }
    }
}
