using UnityEngine;

public class SwingingObstacle : MonoBehaviour
{
    public float speed = 2.0f; // Engel sallanma hızı
    public float maxAngle = 90.0f; // Maksimum açı
    public float minAngle = -90.0f; // Minimum açı

    private bool swingingForward = true;

    void Update()
    {
        float currentAngle = transform.rotation.eulerAngles.z;
        currentAngle = (currentAngle > 180) ? currentAngle - 360 : currentAngle; // Açıları -180 ile 180 arasında tutar

        if (swingingForward)
        {
            currentAngle += speed * Time.deltaTime;
            if (currentAngle >= maxAngle)
            {
                currentAngle = maxAngle;
                swingingForward = false;
            }
        }
        else
        {
            currentAngle -= speed * Time.deltaTime;
            if (currentAngle <= minAngle)
            {
                currentAngle = minAngle;
                swingingForward = true;
            }
        }

        transform.rotation = Quaternion.Euler(0, 0, currentAngle);
    }
}
