using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAnimations : MonoBehaviour
{
    public Animator ghostAnim;
    public KeyCode attackKey = KeyCode.Space;

    // Start is called before the first frame update
    void Start()
    {
        ghostAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {        
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        ghostAnim.SetBool("Flying", isMoving);
        if (Input.GetKeyDown(attackKey))
        {
            ghostAnim.SetBool("Scream", true);
        }
        else if (Input.GetKeyUp(attackKey))
        {
            ghostAnim.SetBool("Scream", false);
        }

    }
}
