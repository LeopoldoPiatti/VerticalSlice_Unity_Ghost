using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimHit : MonoBehaviour
{
    public string hitAnimationBool = "Hit";
    public float hitAnimationDuration = 2f;

    public float raycastDistance;
    public Vector3 rayOffset;
    public LayerMask playerLayerMask;

    private bool canDamage = true;
    public float cooldownTime = 5f;

    private void Update()
    {
        if (canDamage)
        {
            Vector3 rayDirection = transform.forward;
            RaycastHit hit;
            Debug.DrawRay(transform.position + rayOffset, rayDirection * raycastDistance, Color.blue);

            if (Physics.Raycast(transform.position + rayOffset, rayDirection, out hit, raycastDistance, playerLayerMask))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    Animator playerAnimator = hit.collider.GetComponent<Animator>();

                    if (playerAnimator != null)
                    {
                        playerAnimator.SetBool(hitAnimationBool, true);
                        StartCoroutine(RevertToPreviousAnimation(playerAnimator, hitAnimationBool, hitAnimationDuration));
                    }
                    else
                    {
                        Debug.LogError("Player Animator not found!");
                    }

                    canDamage = false;
                    StartCoroutine(CooldownTimer());
                }
            }
        }
    }

    IEnumerator RevertToPreviousAnimation(Animator animator, string boolName, float duration)
    {
        yield return new WaitForSeconds(duration);
        animator.SetBool(boolName, false);
    }

    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(cooldownTime);
        canDamage = true;
    }
}
