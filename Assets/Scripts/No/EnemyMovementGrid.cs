using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementGrid : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidad de movimiento del enemigo
    public GridManager gridManager; // Referencia al script GridManager que crea la grilla

    Vector3 targetPosition;

    void Start()
    {
        // Inicializar la posición de destino al inicio
        SetRandomTargetPosition();
    }

    void Update()
    {
        // Mover hacia la posición de destino
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Verificar si ha alcanzado la posición de destino
        if (Vector3.Distance(transform.position, targetPosition) < 1f)
        {
            // Establecer una nueva posición de destino al azar
            SetRandomTargetPosition();
        }
    }

    void SetRandomTargetPosition()
    {
        // Obtener una posición aleatoria dentro de la grilla
        Vector3 randomPosition = GetRandomGridPosition();

        // Establecer la nueva posición de destino
        targetPosition = randomPosition;
    }

    Vector3 GetRandomGridPosition()
    {
        Vector3 randomPosition;

        // Repetir hasta que se encuentre una posición diferente a la actual
        do
        {
            float randomX = Random.Range(0, gridManager.gridSize) * gridManager.cellSize;
            float randomZ = Random.Range(0, gridManager.gridSize) * gridManager.cellSize;

            randomPosition = new Vector3(randomX, 0, randomZ);
        } while (randomPosition == transform.position);

        return randomPosition;
    }
}
