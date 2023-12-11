using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour
{

    public AudioMixer masterMixer;

    public void SetSoundMaster(float soundLevel)
    {        
        masterMixer.SetFloat("MasterVolume", soundLevel);
    }
    public void SetSoundMusic(float soundLevel)
    {
        masterMixer.SetFloat("MusicVolume", soundLevel);        
    }
    public void SetSoundSFX(float soundLevel)
    {
        masterMixer.SetFloat("SFXVolume", soundLevel);        
    }
}