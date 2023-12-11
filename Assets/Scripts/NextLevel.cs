using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string sceneName;
    public float delayTime = 2.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadSceneWithDelay());
        }
    }

    IEnumerator LoadSceneWithDelay()
    {        
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneName);
    }
}

