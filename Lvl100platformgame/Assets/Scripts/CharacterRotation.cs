using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    public LayerMask groundLayer; // Yüzeylerin bulunduğu Layer
    public float rayLength = 1f; // Ray'in uzunluğu
    float rotationSpeed=50;
    void Update()
    {
        // Karakterin altına doğru bir ray çiz
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);

        if (hit.collider != null)
        {
            // Yüzeyin normalini al
            Vector3 surfaceNormal = hit.normal;

            // Yüzeyin açısını al
            float angle = Mathf.Atan2(surfaceNormal.y, surfaceNormal.x) * Mathf.Rad2Deg;

            // Karakterin rotasyonunu ayarla
           // transform.rotation = Quaternion.Euler(0, 0, angle - 90); // 90 derece çıkartarak karakterin doğru hizalanmasını sağla
           transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle - 90), Time.deltaTime * rotationSpeed);

        }
    }
}
