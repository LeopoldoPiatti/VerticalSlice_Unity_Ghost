using UnityEngine;
using UnityEngine.Audio;

public class CollectibleItem : MonoBehaviour
{
    public AudioClip Sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource playerAudioSource = other.GetComponent<AudioSource>();
            if (playerAudioSource != null)
            {
                playerAudioSource.PlayOneShot(Sound);
            }
            else
            {
                Debug.LogWarning("AudioSource not found on the player object.");
            }

            CollectItem();
        }
    }

    void CollectItem()
    {
        GameManager.Instance.keysNeed += 1;
        gameObject.SetActive(false);
    }
}
