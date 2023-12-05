using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicChange : MonoBehaviour
{
    public AudioMixerSnapshot baseSnapshot;
    public AudioMixerSnapshot calmSnapshot;
    public AudioMixerSnapshot indoorSnapshot;

    public float transitionTime = 0.25f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tension Area")
            calmSnapshot.TransitionTo(transitionTime);

        if (other.gameObject.tag == "Indoor")
            indoorSnapshot.TransitionTo(transitionTime);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Indoor")
            calmSnapshot.TransitionTo(transitionTime);

        if (other.gameObject.tag == "Tension Area")
            baseSnapshot.TransitionTo(transitionTime);
    }
}
