using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{    
    public TextMeshProUGUI lives;
    public TextMeshProUGUI keys;
    
    void Update()
    {
        lives.text = GameManager.Instance.playerLives.ToString();
        keys.text = GameManager.Instance.keysNeed.ToString();
    }    
}
