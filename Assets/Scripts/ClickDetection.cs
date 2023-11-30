using UnityEngine;

public class ClickDetection : MonoBehaviour
{
    public Vector3 clickedPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            
            float rayDistance;
            if (plane.Raycast(ray, out rayDistance))
            {
                clickedPosition = ray.GetPoint(rayDistance);
                clickedPosition.x = Mathf.Round(clickedPosition.x);
                clickedPosition.z = Mathf.Round(clickedPosition.z);
            }
            Debug.Log("Clic izquierdo detectado");
            Debug.Log("Posición del clic en el mundo (redondeada): " + clickedPosition);
        }
    }        
    public bool HasClicked()
    {
        return Input.GetMouseButtonDown(0);
    }
    public Vector3 GetClickedPosition()
    {
        return clickedPosition;
    }
}





