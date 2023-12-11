using System.Collections;
using UnityEngine;

public class ActiveFlashlight : MonoBehaviour
{
    public float raycastDistance;
    public Vector3 rayOffset;
    public LayerMask playerLayerMask;

    private bool canDamage = true;
    public float cooldownTime = 5f;

    public GameObject flashlightObject;

    private void Update()
    {
        if (canDamage)
        {
            Vector3 rayDirection = transform.forward;
            RaycastHit hit;
            Debug.DrawRay(transform.position + rayOffset, rayDirection * raycastDistance, Color.red);

            if (Physics.Raycast(transform.position + rayOffset, rayDirection, out hit, raycastDistance, playerLayerMask))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    flashlightObject.SetActive(true);
                    StartCoroutine(DeactivateAfterCooldown(flashlightObject));
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

    IEnumerator DeactivateAfterCooldown(GameObject objToDeactivate)
    {
        yield return new WaitForSeconds(cooldownTime);

        objToDeactivate.SetActive(false);
    }
}