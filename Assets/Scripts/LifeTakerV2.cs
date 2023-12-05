using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTakerV2 : MonoBehaviour
{
    public int damage;
    public string hitAnimationBool = "Hit";
    public float hitAnimationDuration = 2f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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

    IEnumerator RevertToPreviousAnimation(Animator animator, string boolName, float duration)
    {
        yield return new WaitForSeconds(duration);
        animator.SetBool(boolName, false);
    }
}