using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool grounded;

    void FixedUpdate()
    {        
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1))
        {
            grounded = true;
            Debug.DrawRay(transform.position, Vector3.down, Color.green);
        }
        else
        {
            grounded = false;
            Debug.DrawRay(transform.position, Vector3.down, Color.red);
        }
    }
}
