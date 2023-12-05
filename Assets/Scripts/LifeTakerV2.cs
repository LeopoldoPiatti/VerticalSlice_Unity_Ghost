using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTakerV2 : MonoBehaviour
{
    public int damage;
    public string hitAnimationBool = "Hit";
    public float hitAnimationDuration = 2f;

    public float raycastDistance;
    public Vector3 rayOffset;
    public LayerMask playerLayerMask;

    private void Update()
    {
        RaycastHit hit;
        Vector3 rayDirection = transform.forward;
        Debug.DrawRay(transform.position + rayOffset, rayDirection * raycastDistance, Color.green);
        if (Physics.Raycast(transform.position + rayOffset, rayDirection, out hit, raycastDistance, playerLayerMask))
        {
            if (hit.collider.CompareTag("Player"))
            {
                GameManager.Instance.playerLives -= damage;
                ////Animator playerAnimator = other.GetComponent<Animator>();

                //if (playerAnimator != null)
                //{
                //    playerAnimator.SetBool(hitAnimationBool, true);
                //    StartCoroutine(RevertToPreviousAnimation(playerAnimator, hitAnimationBool, hitAnimationDuration));
                //}
                //else
                //{
                //    Debug.LogError("Player Animator not found!");
                //}
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        RaycastHit hit;
        Vector3 rayDirection = transform.forward;
        Debug.DrawRay(transform.position + rayOffset, rayDirection * raycastDistance, Color.green);
        if (Physics.Raycast(transform.position + rayOffset, rayDirection, out hit, raycastDistance, playerLayerMask))
        {
            if (hit.collider.CompareTag("Player"))
            {
                GameManager.Instance.playerLives -= damage;
                Animator playerAnimator = other.GetComponent<Animator>();

                if (playerAnimator != null)
                {
                    playerAnimator.SetBool(hitAnimationBool, true);
                    StartCoroutine(RevertToPreviousAnimation(playerAnimator, hitAnimationBool, hitAnimationDuration));
                }
                else
                {
                    Debug.LogError("Player Animator not found!");
                }
            }
        }
    }

    IEnumerator RevertToPreviousAnimation(Animator animator, string boolName, float duration)
    {
        yield return new WaitForSeconds(duration);
        animator.SetBool(boolName, false);
    }
}