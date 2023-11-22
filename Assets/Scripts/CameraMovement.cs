using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float velocidadRotacion = 45f;

    void Update()
    {
        MoverCamara();
        RotarCamara();
    }

    void MoverCamara()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direccion = new Vector3(horizontal, 0f, vertical).normalized;

        if (direccion.magnitude >= 0.1f)
        {
            Vector3 movimiento = Camera.main.transform.TransformDirection(direccion);
            movimiento.y = 0;
            transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime, Space.World);
        }
    }

    void RotarCamara()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Rotar la cámara en sentido antihorario (en incrementos de 90 grados)
            transform.Rotate(Vector3.up, -90, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            // Rotar la cámara en sentido horario (en incrementos de 90 grados)
            transform.Rotate(Vector3.up, 90, Space.World);
        }
    }
}


