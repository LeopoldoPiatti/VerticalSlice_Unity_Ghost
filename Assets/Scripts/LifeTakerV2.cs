using System.Collections;
using UnityEngine;

public class LifeTakerV2 : MonoBehaviour
{
    public int damage;
    public float raycastDistance;
    public Vector3 rayOffset;
    public LayerMask playerLayerMask;

    private bool canDamage = true;
    public float cooldownTime = 5f;

    AudioSource flashLightFire;
    public AudioClip flashLightClip;

    private void Start()
    {
        flashLightFire = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (canDamage)
        {
            Vector3 rayDirection = transform.forward;
            RaycastHit hit;
            Debug.DrawRay(transform.position + rayOffset, rayDirection * raycastDistance, Color.green);

            if (Physics.Raycast(transform.position + rayOffset, rayDirection, out hit, raycastDistance, playerLayerMask))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    GameManager.Instance.playerLives -= damage;
                    flashLightFire.PlayOneShot(flashLightClip);

                    canDamage = false;
                    StartCoroutine(CooldownTimer());
                }
            }
        }
    }

    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(cooldownTime);
        canDamage = true;
    }
}

//void OnTriggerEnter(Collider other)
//{
//    RaycastHit hit;
//    Vector3 rayDirection = transform.forward;
//    Debug.DrawRay(transform.position + rayOffset, rayDirection * raycastDistance, Color.green);
//    if (Physics.Raycast(transform.position + rayOffset, rayDirection, out hit, raycastDistance, playerLayerMask))
//    {
//        if (hit.collider.CompareTag("Player"))
//        {
//            GameManager.Instance.playerLives -= damage;
//            Animator playerAnimator = other.GetComponent<Animator>();

//            if (playerAnimator != null)
//            {
//                playerAnimator.SetBool(hitAnimationBool, true);
//                StartCoroutine(RevertToPreviousAnimation(playerAnimator, hitAnimationBool, hitAnimationDuration));
//            }
//            else
//            {
//                Debug.LogError("Player Animator not found!");
//            }
//        }
//    }
//}