using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnvironmentChange : MonoBehaviour
{
    public AudioMixerSnapshot outdoor;
    public AudioMixerSnapshot indoor;

    public float transitionTime = 0.25f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Indoor")
            indoor.TransitionTo(transitionTime);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Indoor")
            outdoor.TransitionTo(transitionTime);
    }
}
