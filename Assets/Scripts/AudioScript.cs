using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    // Volumen máximo almacenado para cada categoría
    private float maxMasterVolume;
    private float maxMusicVolume;
    private float maxSFXVolume;

    void Start()
    {
        // Obtener los valores actuales de los volúmenes y almacenarlos como el volumen máximo
        masterMixer.GetFloat("MasterVolume", out maxMasterVolume);
        masterMixer.GetFloat("MusicVolume", out maxMusicVolume);
        masterMixer.GetFloat("SFXVolume", out maxSFXVolume);

        // Configurar los valores máximos de los sliders
        masterSlider.maxValue = maxMasterVolume;
        musicSlider.maxValue = maxMusicVolume;
        sfxSlider.maxValue = maxSFXVolume;
    }

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