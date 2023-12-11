using System.Collections;
using UnityEngine;

public class ActiveFlashlight : MonoBehaviour
{
    public float raycastDistance;
    public Vector3 rayOffset;
    public LayerMask playerLayerMask;

    public float startAngle;
    public float endAngle;
    public float angleStep = 5f; // Incremento en grados para cada rayo

    private bool canDamage = true;
    public float cooldownTime = 5f;

    public GameObject flashlightObject;

    private void Update()
    {
        ShootRays();
    }

    void ShootRays()
    {
        if (canDamage)
        {
            for (float currentAngle = startAngle; currentAngle <= endAngle; currentAngle += angleStep)
            {
                Vector3 rayDirection = Quaternion.AngleAxis(currentAngle, transform.up) * transform.forward;
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