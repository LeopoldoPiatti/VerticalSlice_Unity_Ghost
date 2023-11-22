using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyOrthographicMovement : MonoBehaviour
{
    public NavMeshAgent agent;

    void Start()
    {
        // Llama a un método para iniciar el movimiento aleatorio
        StartOrthographicMovement();
    }

    public void StartOrthographicMovement()
    {
        // Establece la posición de destino inicial al azar en el plano XZ
        SetRandomDestinationInOrthographicPlane();
    }

    void SetRandomDestinationInOrthographicPlane()
    {
        // Genera una posición aleatoria en el plano XZ
        Vector3 randomPosition = GetRandomPositionInOrthographicPlane();

        // Establece la posición de destino del NavMeshAgent
        agent.SetDestination(randomPosition);
    }

    Vector3 GetRandomPositionInOrthographicPlane()
    {
        // Genera una posición aleatoria en el plano XZ
        float randomX = Random.Range(-10f, 10f); // Ajusta según el tamaño de tu escenario
        float randomZ = Random.Range(-10f, 10f); // Ajusta según el tamaño de tu escenario
        Vector3 randomPosition = new Vector3(randomX, 0f, randomZ);

        return randomPosition;
    }

    void Update()
    {
        // Si el enemigo alcanza su destino actual, establece una nueva posición de destino aleatoria
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            SetRandomDestinationInOrthographicPlane();
        }
    }
}
