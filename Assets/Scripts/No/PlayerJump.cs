using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce = 10f;
    public int maxAirJumps = 1;
    private int remainingAirJumps;

    private GroundDetector groundDetector;

    void Start()
    {
        groundDetector = GetComponent<GroundDetector>();
        remainingAirJumps = maxAirJumps;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (groundDetector.grounded)
            {                
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                remainingAirJumps = maxAirJumps; 
            }
            else if (remainingAirJumps > 0)
            {                
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                remainingAirJumps--; 
            }
        }
    }
}


