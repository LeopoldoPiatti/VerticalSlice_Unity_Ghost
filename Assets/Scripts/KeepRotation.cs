using UnityEngine;

public class KeepRotation : MonoBehaviour
{
    public float targetRotation;
    public Vector3 targetPosition;
    public GameObject objRotation;

    void Update()
    {
        objRotation.transform.localPosition = targetPosition;
        objRotation.transform.localRotation = Quaternion.Euler(0f, targetRotation, 0f);
    }
}
