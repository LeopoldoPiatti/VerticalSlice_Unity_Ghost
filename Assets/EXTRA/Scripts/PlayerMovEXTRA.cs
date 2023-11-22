using UnityEngine;

public class PlayerMovEXTRA : MonoBehaviour
{
    public float playerRotationSpeed;
    public GameObject player;
    public Vector3 deltaMove;
    public float moveSpeed;
    public float airborneMoveSpeed;
    private GroundDetectorEXTRA groundDetector;

    void Start()
    {
        groundDetector = GetComponent<GroundDetectorEXTRA>();
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        Quaternion cuerpoRotation = Quaternion.Euler(0f, mouseX * playerRotationSpeed, 0f);
        Quaternion newRotation = transform.rotation * cuerpoRotation;
        transform.rotation = newRotation;

        if (groundDetector != null && groundDetector.grounded)
        {
           deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * moveSpeed * Time.deltaTime;
        }
        else
        {
           deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * airborneMoveSpeed * Time.deltaTime;
        }

        player.transform.Translate(deltaMove);
    }
}