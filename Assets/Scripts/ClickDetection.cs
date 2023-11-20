using UnityEngine;

public class ClickDetection : MonoBehaviour
{
    // Variable para almacenar la posici�n clicada
    public Vector3 clickedPosition;

    void Update()
    {
        // Detectar el clic izquierdo del mouse (bot�n 0)
        if (Input.GetMouseButtonDown(0))
        {
            // Obtener un rayo desde la posici�n del rat�n
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Crear un plano en el mismo plano que tu objeto de referencia (en este caso, el plano XZ)
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            // Intersectar el rayo con el plano
            float rayDistance;
            if (plane.Raycast(ray, out rayDistance))
            {
                // Obtener la posici�n de intersecci�n en el mundo
                clickedPosition = ray.GetPoint(rayDistance);

                // Redondear la posici�n a la unidad m�s cercana
                clickedPosition.x = Mathf.Round(clickedPosition.x);
                clickedPosition.z = Mathf.Round(clickedPosition.z);
            }

            // Aqu� puedes agregar el c�digo que deseas ejecutar cuando se hace clic izquierdo
            Debug.Log("Clic izquierdo detectado");
            Debug.Log("Posici�n del clic en el mundo (redondeada): " + clickedPosition);
        }
    }

    // M�todo para verificar si se ha hecho clic
    public bool HasClicked()
    {
        return Input.GetMouseButtonDown(0);
    }

    // M�todo para obtener la posici�n clicada
    public Vector3 GetClickedPosition()
    {
        return clickedPosition;
    }
}





