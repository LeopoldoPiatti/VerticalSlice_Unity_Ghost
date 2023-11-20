using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    public NavMeshAgent agent;

    // Variables para gestionar el movimiento en dos pasos
    private bool firstStepComplete = false;
    private Vector3 targetPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray movePosition = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(movePosition, out var hitInfo))
            {
                // Si el primer paso ya se ha completado, establece la posición de destino en ambos ejes y reinicia la variable
                if (firstStepComplete)
                {
                    targetPosition = new Vector3(transform.position.x, transform.position.y, hitInfo.point.z);
                    firstStepComplete = false;
                }
                // Si el primer paso no se ha completado, establece la posición de destino solo en el eje x y marca el primer paso como completo
                else
                {
                    targetPosition = new Vector3(hitInfo.point.x, transform.position.y, transform.position.z);
                    firstStepComplete = true;
                }

                // Establece la posición de destino del NavMeshAgent
                agent.SetDestination(targetPosition);
            }
        }
    }
}


