using UnityEngine;

public class DoorMechanicsPlayer : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public Vector3 rotationAxis = Vector3.up;
    public int requiredKeys;

    private bool isDoorOpen = false;

    private void Update()
    {
        if (isDoorOpen)
        {
            RotateDoor();
        }
    }

    private void RotateDoor()
    {
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
        if (transform.rotation.eulerAngles.y >= 90f) 
        {
            isDoorOpen = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        if (GameManager.Instance.keysNeed >= requiredKeys)
        {
            if (!isDoorOpen)
            {
                Debug.Log("Opening door!");
                isDoorOpen = true;
            }
        }
        else
        {
            Debug.Log("Not enough keys!");
        }
    }
}