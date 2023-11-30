using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int playerLives;
    public int keysNeed;
        
    void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        
    }
}
