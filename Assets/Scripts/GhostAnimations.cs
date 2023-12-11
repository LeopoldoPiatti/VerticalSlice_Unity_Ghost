using System.Collections;
using UnityEngine;

public class GhostAnimations : MonoBehaviour
{
    public Animator ghostAnim;    
    public KeyCode attackKey = KeyCode.Space;
    public float animCooldownTime = 2.0f;
    private bool canAttack = true;
    

    void Start()
    {        
        if (ghostAnim == null)
        {
            GameObject ghostLowRig = GameObject.Find("Ghost_low_rig");

            if (ghostLowRig != null)
            {
                ghostAnim = ghostLowRig.GetComponent<Animator>();
            }            
        }       
    }
    
    void Update()
    {        
        AnimAttack();       
    }

    void AnimAttack()
    {     
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        ghostAnim.SetBool("Walking", isMoving);

        if (Input.GetKeyDown(attackKey) && canAttack)
        {
            StartCoroutine(AnimCooldown());
        }
    }
    IEnumerator AnimCooldown()
    {       
        canAttack = false;
        ghostAnim.SetBool("Scream", true);        
        yield return new WaitForSeconds(animCooldownTime);
        ghostAnim.SetBool("Scream", false);
        canAttack = true;
    }
}