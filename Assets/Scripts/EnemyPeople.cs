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

    public Animator humanAnim;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetSpeed(normalSpeed);
        SetDestination();
        if (humanAnim == null)
        {
            GameObject humanRig = GameObject.Find("Human_l_rig");

            if (humanRig != null)
            {
                humanAnim = humanRig.GetComponent<Animator>();
            }
        }
    }

    void Update()
    {
        if (!isFleeing && navMeshAgent.remainingDistance < 0.1f)
        {
            objective = (objective + 1) % points.Count;
            SetDestination();
            humanAnim.SetBool("Run", false);
        }

        if (isFleeing)
        {
            timeSinceFleeStart += Time.deltaTime;

            if (fleeWaitTime > 0f && timeSinceFleeStart >= fleeWaitTime)
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
            humanAnim.SetBool("Run", true);
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
