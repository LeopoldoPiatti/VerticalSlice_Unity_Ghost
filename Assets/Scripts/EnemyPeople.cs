using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPeople : MonoBehaviour
{
    public List<Transform> points;
    public float normalSpeed = 5.0f;
    public float fleeSpeed = 10.0f;
    public float fleeWaitTime = 3.0f;

    private NavMeshAgent navMeshAgent;
    private int objective = 0;
    private bool isFleeing = false;
    private float timeSinceFleeStart;

    public Transform fleeDestination;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetSpeed(normalSpeed);
        SetDestination();
    }

    void Update()
    {
        if (!isFleeing && navMeshAgent.remainingDistance < 0.1f)
        {
            objective = (objective + 1) % points.Count;
            SetDestination();
        }

        if (isFleeing)
        {
            timeSinceFleeStart += Time.deltaTime;

            if (timeSinceFleeStart >= fleeWaitTime)
            {
                isFleeing = false;
                timeSinceFleeStart = 0f;
                SetSpeed(normalSpeed);
                SetDestination();
            }
        }
    }

    void SetDestination()
    {
        if (!isFleeing)
        {
            navMeshAgent.SetDestination(points[objective].position);
        }
    }

    public void Flee()
    {
        if (fleeDestination != null)
        {
            navMeshAgent.SetDestination(fleeDestination.position);
            SetSpeed(fleeSpeed);
            isFleeing = true;
        }
        else
        {
            Debug.LogError("Flee destination not assigned!");
        }
    }

    void SetSpeed(float speed)
    {
        navMeshAgent.speed = speed;
    }
}