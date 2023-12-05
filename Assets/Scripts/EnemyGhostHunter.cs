using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGhostHunter : MonoBehaviour
{
    public List<Transform> points;
    public float speed;
    public int damage;

    public float raycastDistance;    
    public Vector3 rayOffset;
    public LayerMask playerLayerMask;
    public float chaseSpeed;

    private NavMeshAgent navMeshAgent;
    private int objective = 0;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed;
        SetDestination();
    }

    void Update()
    {
        if (navMeshAgent.remainingDistance < 0.1f)
        {
            objective = (objective + 1) % points.Count;
            SetDestination();            
        }

        RaycastHit hit;
        Vector3 rayDirection = transform.forward;
        Debug.DrawRay(transform.position + rayOffset, rayDirection * raycastDistance, Color.green);
        if (Physics.Raycast(transform.position + rayOffset, rayDirection, out hit, raycastDistance, playerLayerMask))
        {             
            if (hit.collider.CompareTag("Player"))
            {
                ChasePlayer(hit.collider.transform);
            }
        }
    }

    void SetDestination()
    {        
        navMeshAgent.SetDestination(points[objective].position);
    }

    void ChasePlayer(Transform playerTransform)
    {
        navMeshAgent.speed = chaseSpeed;
        navMeshAgent.SetDestination(playerTransform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            GameManager.Instance.playerLives -= damage;
        }
    }
}
