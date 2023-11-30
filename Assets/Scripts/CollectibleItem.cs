using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    //public CameraShake cameraShake;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectItem();
            //cameraShake.ShakeCamera();
        }
    }

    void CollectItem()
    {
        GameManager.Instance.keysNeed += 1;
        gameObject.SetActive(false);
    }
}