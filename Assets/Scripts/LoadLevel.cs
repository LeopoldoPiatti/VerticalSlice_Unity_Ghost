using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class LoadLevel : MonoBehaviour
{
    //public GameObject objectToActivate;
    //public GameObject objectToDeactivate;

    public Transform newPosition;

    public string sceneName;

    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }
    
    public void setactive(GameObject canvasactive)
    {
        canvasactive.SetActive(true);
    }

    public void setdesactive(GameObject canvasdesactive)
    {
        canvasdesactive.SetActive(false);
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        Lowpass();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Lowpass();
    }
    void Lowpass()
    {
        if (Time.timeScale == 0)
        {
            paused.TransitionTo(.01f);
        }
        else
        {
            unpaused.TransitionTo(0.1f);
        }
    }
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }    
}
