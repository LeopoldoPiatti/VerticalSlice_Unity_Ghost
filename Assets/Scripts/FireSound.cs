using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSound : MonoBehaviour
{
    public AudioClip fireSound;
    void PlayFireSound()
    {
        AudioSource aSource = GetComponent<AudioSource>();
        aSource.pitch = Random.Range(0.9f, 1.1f);
        aSource.volume = Random.Range(0.9f, 1.0f);

        aSource.PlayOneShot(fireSound);
    }
}
