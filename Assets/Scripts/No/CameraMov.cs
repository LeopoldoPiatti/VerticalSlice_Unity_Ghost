using UnityEngine;

public class CameraMov : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = .5f;
    public float cameraRotationSpeed;
    public float yMin = -0.5f;
    public float yMax = 0.5f;

    void Update()
    {
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        turn.y = Mathf.Clamp(turn.y, yMin, yMax);
        transform.localRotation = Quaternion.Euler(-turn.y, 0 , 0);
    }
}

