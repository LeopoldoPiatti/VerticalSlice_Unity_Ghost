using UnityEngine;

public class CursorScriptEXTRA : MonoBehaviour
{   
    void Start()
    {        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
