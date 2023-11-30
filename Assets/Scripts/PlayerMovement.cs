using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveDistance = 1f;
    public float rotationSpeed = 10f;
    private Rigidbody rb;
    private GroundDetector groundDetector;
    public Vector3 accumulatedMovement;
    public Transform playerCameraObj;    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundDetector = GetComponent<GroundDetector>();
    }

    void Update()
    {
        MovementInput();
        MovePlayer();
    }

    void MovementInput()
    {
        if (groundDetector.grounded)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            float cameraYRotation = playerCameraObj.rotation.eulerAngles.y;

            if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput) && (cameraYRotation == 0f))
            {
                accumulatedMovement = new Vector3(horizontalInput, 0f, 0f).normalized;
            }
            else if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput) && cameraYRotation == 90f)
            {
                accumulatedMovement = new Vector3(-horizontalInput, 0f, 0f).normalized;
            }
            else if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput) && (cameraYRotation == 180f))
            {
                accumulatedMovement = new Vector3(-horizontalInput, 0f, 0f).normalized;
            }
            else if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput) && (cameraYRotation == -90f))
            {
                accumulatedMovement = new Vector3(horizontalInput, 0f, 0f).normalized;
            }
            else 
            {
                accumulatedMovement = new Vector3(0f, 0f, verticalInput).normalized;
            }
        }
    }

    void MovePlayer()
    {
        Vector3 newPosition = rb.position + accumulatedMovement * moveDistance;
        rb.MovePosition(Vector3.Lerp(rb.position, newPosition, Time.deltaTime));

        if (accumulatedMovement != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(accumulatedMovement);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, newRotation, Time.deltaTime * rotationSpeed));
        }
    }
}

//void MovementInput()
//{
//    if (groundDetector.grounded)
//    {
//        float horizontalInput = Input.GetAxis("Horizontal");
//        float verticalInput = Input.GetAxis("Vertical");

//        if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput))
//        {
//            accumulatedMovement = new Vector3(horizontalInput, 0f, 0f).normalized;
//        }
//        else
//        {
//            accumulatedMovement = new Vector3(0f, 0f, verticalInput).normalized;
//        }
//    }
//}