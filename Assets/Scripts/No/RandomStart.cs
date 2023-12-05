using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSource aSource = GetComponent<AudioSource>();
        aSource.time = Random.Range(0.0f, aSource.clip.length);
        aSource.Play();
    }
}
