using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTakerV2 : MonoBehaviour
{
    public int damage;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.playerLives -= damage;
        }
    }
}
