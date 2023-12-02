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

            // Obtener la dirección de movimiento relativa a la cámara
            Vector3 camForward = playerCameraObj.forward;
            Vector3 camRight = playerCameraObj.right;
            camForward.y = 0f;
            camRight.y = 0f;
            camForward.Normalize();
            camRight.Normalize();

            // Obtener la dirección de movimiento combinando las direcciones relativas
            accumulatedMovement = camForward * verticalInput + camRight * horizontalInput;
        }
    }



    void MovePlayer()
    {
        Vector3 newPosition = rb.position + accumulatedMovement * moveDistance;
        rb.MovePosition(Vector3.Lerp(rb.position, newPosition, Time.deltaTime));

        if (accumulatedMovement != Vector3.zero)
        {
            // Calcular la rotación basada en la entrada del jugador
            float angle = Mathf.Atan2(accumulatedMovement.x, accumulatedMovement.z) * Mathf.Rad2Deg;
            Quaternion newRotation = Quaternion.Euler(0f, angle, 0f);

            // Aplicar rotación suavemente
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, newRotation, Time.deltaTime * rotationSpeed));
        }
    }
}