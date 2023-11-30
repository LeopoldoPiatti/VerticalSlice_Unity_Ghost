using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int playerLives;
    public int keysNeed;
    public Transform chekpointObj;
    public Transform playerObj;
    public string sceneName;

    void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (playerLives <= 0)
        {
            SceneManager.LoadScene(sceneName);
            //playerObj.transform.position = chekpointObj.transform.position;
        }
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
