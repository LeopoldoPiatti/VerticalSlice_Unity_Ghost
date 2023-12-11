using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyerCollider : MonoBehaviour
{
    public float delay = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DeactivateObjectWithDelay());
        }
    }

    private IEnumerator DeactivateObjectWithDelay()
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}

