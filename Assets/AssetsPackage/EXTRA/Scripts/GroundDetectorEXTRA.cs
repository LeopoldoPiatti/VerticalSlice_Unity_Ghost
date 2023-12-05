using UnityEngine;

public class GroundDetectorEXTRA : MonoBehaviour
{
    public bool grounded;
    public string tagPlatform;

    void FixedUpdate()
    {
        // Mantén tu lógica de Raycast para actualizar la variable 'grounded'
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagPlatform)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1) && hit.collider.tag == tagPlatform)
            {
                transform.SetParent(other.transform, true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        grounded = false;
        if (other.tag == tagPlatform)
        {
            transform.SetParent(null, true);
        }
    }
}




