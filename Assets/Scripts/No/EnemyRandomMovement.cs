using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyOrthographicMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform destinationPoint1;
    public Transform destinationPoint2;

    void Start()
    {
        // Llama a un método para iniciar el movimiento entre los dos puntos
        StartOrthographicMovement();
    }

    public void StartOrthographicMovement()
    {
        // Establece la posición de destino inicial al primer punto
        SetDestination(destinationPoint1.position);
    }

    void SetDestination(Vector3 destination)
    {
        // Establece la posición de destino del NavMeshAgent
        agent.SetDestination(destination);
    }

    void Update()
    {
        // Si el enemigo alcanza su destino actual, cambia al siguiente punto de destino
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            SwitchDestination();
        }
    }

    void SwitchDestination()
    {
        // Cambia entre los dos puntos de destino
        if (agent.destination == destinationPoint1.position)
        {
            SetDestination(destinationPoint2.position);
        }
        else
        {
            SetDestination(destinationPoint1.position);
        }
    }
}

