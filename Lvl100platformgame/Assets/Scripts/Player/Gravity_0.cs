using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_0 : MonoBehaviour
{
    Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
          player.rb.gravityScale=0;
    }
}
