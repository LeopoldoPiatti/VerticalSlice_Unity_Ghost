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

    public Animator hunterAnim;
    //public GameObject hitFlash;

    //public Transform hitFlashPosition;
    //public GameObject targetObject;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed;
        SetDestination();
        if (hunterAnim == null)
        {
            GameObject hunterRig = GameObject.Find("GhostHunter_l_rig");

            if (hunterRig != null)
            {
                hunterAnim = hunterRig.GetComponent<Animator>();
            }
        }
    }

    void Update()
    {
        if (navMeshAgent.remainingDistance < 0.1f)
        {
            objective = (objective + 1) % points.Count;
            navMeshAgent.speed = speed;
            SetDestination();
            hunterAnim.SetBool("Fire", false);
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
        navMeshAgent.SetDestination(playerTransform.position);
        navMeshAgent.speed = chaseSpeed;
        hunterAnim.SetBool("Fire", true);
        //GameObject hitInstance = Instantiate(hitFlash, hitFlashPosition);
        //hitInstance.transform.parent = transform;
        //hitInstance.transform.localPosition = Vector3.zero;
        //hitInstance.transform.localRotation = Quaternion.identity;
        //Destroy(hitInstance, 1.0f);


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.playerLives -= damage;
        }
    }
}

