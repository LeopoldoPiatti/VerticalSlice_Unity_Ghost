using UnityEngine;

public class CursorScript : MonoBehaviour
{   
    void Start()
    {        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
