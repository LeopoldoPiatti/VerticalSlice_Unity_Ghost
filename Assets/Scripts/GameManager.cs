using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int playerLives;
    public int keysNeed;
    public string sceneName;
    public float delayTime = 2.0f;

    public AudioSource playerSourceAudio;
    public AudioClip endSound;

    void Awake()
    {        
        Instance = this;
        //DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        if (playerSourceAudio == null)
        {
            GameObject playerAudio = GameObject.Find("Player");

            if (playerAudio != null)
            {
                playerSourceAudio = playerAudio.GetComponent<AudioSource>();
            }
        }
    }

    private void Update()
    {
        if (playerLives <= 0)
        {
            playerSourceAudio.PlayOneShot(endSound);
            StartCoroutine(LoadSceneWithDelay());
        }

        Cheats();
    }
    IEnumerator LoadSceneWithDelay()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneName);
    }

    void Cheats()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            playerLives++;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            keysNeed++;
        }
    }
}