using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip[] foostepsOnGrass;
    public AudioClip[] foostepsOnWood;

    public string material = "Grass";

    void PlayFoostepSound()
    {
        AudioSource aSource = GetComponent<AudioSource>();
        aSource.pitch = Random.Range(0.9f, 1.1f);
        aSource.volume = Random.Range(0.9f, 1.0f);

        AudioClip clipToPlay;
        switch (material)
        {
            case "Grass":
                clipToPlay = foostepsOnGrass[Random.Range(0, foostepsOnGrass.Length)];
                aSource.PlayOneShot(clipToPlay);
                break;

            case "Wood":
                clipToPlay = foostepsOnWood[Random.Range(0, foostepsOnWood.Length)];
                aSource.PlayOneShot(clipToPlay);
                break;

            default:
                break;
        }       
    }

    private void OnCollisionEnter(Collision collision)
    {
        string myTag = collision.gameObject.tag;
        switch (myTag)
        {
            case "Grass":
            case "Wood":
                material = myTag;
                break;

            default:
                break;
        }
    }
}
