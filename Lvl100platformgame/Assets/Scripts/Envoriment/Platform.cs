using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] Transform[] pos;

    public float speed = 3f; // Platformun hızı

    private Vector3 targetPosition;
    void Start()
    {
        // Başlangıç hedef pozisyonu A noktası
        targetPosition = pos[0].position;

        foreach (Transform item in pos)
        {
            item.parent = null;
        }
    }
    private void Update()
    {
        // Platformu hedef pozisyona doğru hareket ettir
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Hedef pozisyona ulaştığında hedefi değiştir
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (targetPosition == pos[0].position)
            {
                targetPosition = pos[1].position;
            }
            else
            {
                targetPosition = pos[0].position;
            }
        }

    }
}
