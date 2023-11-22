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
        // Inicializar la posici�n de destino al inicio
        SetRandomTargetPosition();
    }

    void Update()
    {
        // Mover hacia la posici�n de destino
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Verificar si ha alcanzado la posici�n de destino
        if (Vector3.Distance(transform.position, targetPosition) < 1f)
        {
            // Establecer una nueva posici�n de destino al azar
            SetRandomTargetPosition();
        }
    }

    void SetRandomTargetPosition()
    {
        // Obtener una posici�n aleatoria dentro de la grilla
        Vector3 randomPosition = GetRandomGridPosition();

        // Establecer la nueva posici�n de destino
        targetPosition = randomPosition;
    }

    Vector3 GetRandomGridPosition()
    {
        Vector3 randomPosition;

        // Repetir hasta que se encuentre una posici�n diferente a la actual
        do
        {
            float randomX = Random.Range(0, gridManager.gridSize) * gridManager.cellSize;
            float randomZ = Random.Range(0, gridManager.gridSize) * gridManager.cellSize;

            randomPosition = new Vector3(randomX, 0, randomZ);
        } while (randomPosition == transform.position);

        return randomPosition;
    }
}
