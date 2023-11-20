using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveDistance = 1f; // Ajusta la distancia según tus necesidades
    private Rigidbody rb;
    private Vector3 targetPosition;
    public float interpolationTime = 1f; // Ajusta el tiempo de interpolación según tus necesidades

    void Start()
    {
        // Obtener el componente Rigidbody
        rb = GetComponent<Rigidbody>();

        // Verificar si se encontró el componente Rigidbody
        if (rb == null)
        {
            Debug.LogError("No se encontró el componente Rigidbody en el mismo GameObject.");
        }
    }

    void Update()
    {
        // Mover hacia adelante con la tecla W
        if (Input.GetKeyDown(KeyCode.W))
        {
            MovePlayer(Vector3.forward);
        }

        // Mover hacia atrás con la tecla S
        if (Input.GetKeyDown(KeyCode.S))
        {
            MovePlayer(Vector3.back);
        }

        // Mover hacia la izquierda con la tecla A
        if (Input.GetKeyDown(KeyCode.A))
        {
            MovePlayer(Vector3.left);
        }

        // Mover hacia la derecha con la tecla D
        if (Input.GetKeyDown(KeyCode.D))
        {
            MovePlayer(Vector3.right);
        }

        // Mover suavemente hacia la posición objetivo
        rb.MovePosition(Vector3.Lerp(rb.position, targetPosition, Time.deltaTime / interpolationTime));
    }

    void MovePlayer(Vector3 direction)
    {
        // Calcular la posición a la que se moverá el jugador
        targetPosition = rb.position + direction * moveDistance;
    }
}




