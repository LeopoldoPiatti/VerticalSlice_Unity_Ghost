using UnityEngine;

public class DoorMechanics : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public Vector3 rotationAxis = Vector3.up;
    public int requiredKeys;    
    private bool isDoorOpen = false;
    public CameraShake cameraShake;

    public Camera mainCamera;
    public Vector3 originalCameraPosition;
    public float returnDelay;

    private void Start()
    {
        mainCamera = Camera.main;
        
    }

    private void Update()
    {
        if (GameManager.Instance.keysNeed >= requiredKeys)
        {            
            RotateDoor();
            LookDoorOpening();
        }
    }

    private void RotateDoor()
    {
        isDoorOpen = true;
        if (isDoorOpen == true)
        {
            transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
            if (transform.rotation.eulerAngles.y >= 90f)
            {
                cameraShake.ShakeCamera();
                isDoorOpen = false;
                enabled = false;
            }
        }
    }


    private void LookDoorOpening()
    {
        Vector3 targetCameraPosition = transform.position;               
        mainCamera.transform.position = targetCameraPosition;

        if (isDoorOpen == false)
        {
            Invoke("RestoreOriginalCameraPosition", returnDelay);
        }
    }

    private void RestoreOriginalCameraPosition()
    {
        mainCamera.transform.localPosition = originalCameraPosition;
    }    
}

//private void LookDoorOpening()
//{
//    Vector3 currentCameraPosition = mainCamera.transform.position;
//    Vector3 targetCameraPosition = transform.position;
//    mainCamera.transform.position = Vector3.Lerp(currentCameraPosition, targetCameraPosition, Time.deltaTime);
//    if (isDoorOpen == false)
//    {
//        mainCamera.transform.position = originalCameraPosition;
//    }
//}

//// M�todo que gira la puerta.
//private void RotateDoor()
//{
//    // Establece que la puerta est� abierta.
//    isDoorOpen = true;

//    // Verifica si la puerta est� abierta.
//    if (isDoorOpen == true)
//    {
//        // Rota la puerta alrededor del eje especificado.
//        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);

//        // Hace temblar la c�mara en cada fotograma durante la rotaci�n.
//        cameraShake.ShakeCamera();

//        // Verifica si la rotaci�n alcanza cierto �ngulo (90 grados en este caso).
//        if (transform.rotation.eulerAngles.y >= 90f)
//        {
//            // Establece que la puerta est� cerrada y desactiva este script.
//            isDoorOpen = false;
//            enabled = false;
//        }
//    }
//}