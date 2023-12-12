using UnityEngine;

public class RayByAngle : MonoBehaviour
{
    public float startAngle;
    public float endAngle;
    public float angleStep = 5f;
    public float distance = 1f;

    void Update()
    {
        ShootRays();
    }

    void ShootRays()
    {
        for (float currentAngle = startAngle; currentAngle <= endAngle; currentAngle += angleStep)
        {
            var direction = Quaternion.AngleAxis(currentAngle, transform.up) * transform.forward;
            Ray ray = new Ray(transform.position, direction);

            Debug.DrawLine(ray.origin, ray.origin + ray.direction * distance, Color.red);

            if (Physics.Raycast(ray, distance))
            {
                Debug.Log("Something is there at angle: " + currentAngle);
            }
        }
    }
}
