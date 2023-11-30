using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    
    public GameObject player;
    public Vector3 deltaMove;
    public float moveSpeed;
    private Rigidbody rb;
    public float rotationSpeed = 10f;

    private GroundDetector groundDetector;

    void Start()
    {
        groundDetector = GetComponent<GroundDetector>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (groundDetector != null && groundDetector.grounded) 
        {        
            deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * moveSpeed * Time.deltaTime;
            player.transform.Translate(deltaMove);

            if (player.transform.position != Vector3.zero)
            {
                //Quaternion newRotation = Quaternion.LookRotation(deltaMove.normalized);
                //player.transform.rotation = Quaternion.Slerp(player.transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
            }
        }
        RotarPlayer();
    }
    void RotarPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -90, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(Vector3.up, 90, Space.World);
        }
    }
}
