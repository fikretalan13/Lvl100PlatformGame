using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_Skills : MonoBehaviour
{
    bool isSpeedSkillsTaken = false;
    public float timer;
    SpriteRenderer spriteRenderer;
    BoxCollider2D speedCollider;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        speedCollider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isSpeedSkillsTaken = true;
            if (isSpeedSkillsTaken)
            {
                Player.instance.playerSpeed =24;
            }
            StartCoroutine(SpeedSkill());
            speedCollider.enabled = false;
            spriteRenderer.enabled = false;

        }

        IEnumerator SpeedSkill()
        {
            yield return new WaitForSeconds(timer);
            Player.instance.playerSpeed = 12;
            isSpeedSkillsTaken = false;
        }
    }
}
