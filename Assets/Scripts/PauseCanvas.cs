using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseCanvas : MonoBehaviour
{
    Canvas pauseCanvas;

    public GameObject pausePanel;

    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;
    public void Start()
    {
        pauseCanvas = GetComponent<Canvas>();           
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pauseCanvas.enabled = !pauseCanvas.enabled;
            pausePanel.SetActive(!pausePanel.activeSelf);
            Pause();
            Lowpass();
        }
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

    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
}
