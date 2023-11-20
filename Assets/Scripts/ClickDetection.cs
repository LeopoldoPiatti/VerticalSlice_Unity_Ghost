using UnityEngine;

public class ClickDetection : MonoBehaviour
{
    // Variable para almacenar la posición clicada
    public Vector3 clickedPosition;

    void Update()
    {
        // Detectar el clic izquierdo del mouse (botón 0)
        if (Input.GetMouseButtonDown(0))
        {
            // Obtener un rayo desde la posición del ratón
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Crear un plano en el mismo plano que tu objeto de referencia (en este caso, el plano XZ)
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            // Intersectar el rayo con el plano
            float rayDistance;
            if (plane.Raycast(ray, out rayDistance))
            {
                // Obtener la posición de intersección en el mundo
                clickedPosition = ray.GetPoint(rayDistance);

                // Redondear la posición a la unidad más cercana
                clickedPosition.x = Mathf.Round(clickedPosition.x);
                clickedPosition.z = Mathf.Round(clickedPosition.z);
            }

            // Aquí puedes agregar el código que deseas ejecutar cuando se hace clic izquierdo
            Debug.Log("Clic izquierdo detectado");
            Debug.Log("Posición del clic en el mundo (redondeada): " + clickedPosition);
        }
    }

    // Método para verificar si se ha hecho clic
    public bool HasClicked()
    {
        return Input.GetMouseButtonDown(0);
    }

    // Método para obtener la posición clicada
    public Vector3 GetClickedPosition()
    {
        return clickedPosition;
    }
}





