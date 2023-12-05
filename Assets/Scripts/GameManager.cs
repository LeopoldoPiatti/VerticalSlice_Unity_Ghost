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
    public Transform checkpointObj;
    public Transform playerObj;
    public string sceneName;

    void Awake()
    {
        // Si ya existe una instancia del GameManager, destruye la instancia actual.
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // Si no hay instancia, establece esta instancia como la instancia activa.
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (playerLives <= 0)
        {
            SceneManager.LoadScene(sceneName);
            //playerObj.transform.position = checkpointObj.transform.position;
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}