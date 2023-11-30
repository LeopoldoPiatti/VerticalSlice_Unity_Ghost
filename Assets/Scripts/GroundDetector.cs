using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GroundDetector : MonoBehaviour
{
    public Vector3 offset;
    public float length;
    public LayerMask layerMask;
    public bool grounded;

    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position + offset, -transform.up * length, Color.red);
        if (Physics.Raycast(transform.position + offset, -transform.up, out hit, length, layerMask))
        {
            Debug.DrawRay(transform.position + offset, -transform.up * hit.distance, Color.green);
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
}