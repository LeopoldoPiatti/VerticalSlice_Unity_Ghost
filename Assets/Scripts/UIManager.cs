using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{    
    public TextMeshProUGUI lives;
    public TextMeshProUGUI keys;
    
    void Start()
    {
        
    }

    void Update()
    {
        lives.text = "Lives: " + GameManager.Instance.playerLives.ToString();
        keys.text = "Keys:" + GameManager.Instance.keysNeed.ToString();
    }    
}
