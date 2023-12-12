using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveDistance = 1f;
    public float rotationSpeed = 10f;
    private Rigidbody rb;
    private GroundDetector groundDetector;
    public Vector3 accumulatedMovement;
    public Transform playerCameraObj;
    public GameObject restartPosition;
    public GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundDetector = GetComponent<GroundDetector>();
    }

    void Update()
    {
        MovementInput();
        MovePlayer();
        RestartPlayer();
    }

    void MovementInput()
    {
        if (groundDetector.grounded)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 camForward = playerCameraObj.forward;
            Vector3 camRight = playerCameraObj.right;
            camForward.y = 0f;
            camRight.y = 0f;
            camForward.Normalize();
            camRight.Normalize();
            accumulatedMovement = camForward * verticalInput + camRight * horizontalInput;
        }
    }

    void MovePlayer()
    {
        Vector3 newPosition = rb.position + accumulatedMovement * moveDistance;
        rb.MovePosition(Vector3.Lerp(rb.position, newPosition, Time.deltaTime));

        if (accumulatedMovement != Vector3.zero)
        {
            float angle = Mathf.Atan2(accumulatedMovement.x, accumulatedMovement.z) * Mathf.Rad2Deg;
            Quaternion newRotation = Quaternion.Euler(0f, angle, 0f);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, newRotation, Time.deltaTime * rotationSpeed));
        }
    }

    void RestartPlayer()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            player.transform.position = restartPosition.transform.position;
        }
    }
}