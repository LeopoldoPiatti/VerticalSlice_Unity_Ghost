using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItemRotation : MonoBehaviour
{
    public float rotationSpeed;
    public float floatSpeed;
    public float minFloatHeight;
    public float maxFloatHeight;

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        float newY = Mathf.Lerp(minFloatHeight, maxFloatHeight, Mathf.PingPong(Time.time * floatSpeed, 1f));
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
