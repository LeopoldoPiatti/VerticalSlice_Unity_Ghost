using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictorySound : MonoBehaviour
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
        }

    }
}