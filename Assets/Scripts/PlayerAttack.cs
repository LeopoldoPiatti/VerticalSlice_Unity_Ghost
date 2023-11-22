using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttack : MonoBehaviour
{
    public KeyCode attackKey = KeyCode.Space;
    public float radius;
    public float cooldownTime = 2.0f; // Time in seconds between attacks
    public float fleeTime = 3.0f; // Time in seconds for fleeing
    public float resumeTime = 2.0f; // Time in seconds to resume movement
    bool canAttack = true;
    public LayerMask enemyLayer; // Layer of objects to interact with the attack
    public GameObject attackWave;

    private void Update()
    {
        if (Input.GetKeyDown(attackKey) && canAttack)
        {
            Attack();
            StartCoroutine(Cooldown());
        }
    }

    void Attack()
    {
        GameObject waveInstance = Instantiate(attackWave, transform.position, transform.rotation);
        Destroy(waveInstance, 1.0f);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, enemyLayer);

        foreach (Collider nearbyObjects in colliders)
        {
            NavMeshAgent navMeshAgent = nearbyObjects.GetComponent<NavMeshAgent>();
            if (navMeshAgent != null)
            {
                // Stop the enemy
                navMeshAgent.isStopped = true;

                // Start the coroutine to resume movement after a delay
                StartCoroutine(FleeAndResume(navMeshAgent));
            }
        }
    }

    IEnumerator Cooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldownTime);
        canAttack = true;
    }

    IEnumerator FleeAndResume(NavMeshAgent navMeshAgent)
    {
        // Wait for the flee time
        yield return new WaitForSeconds(fleeTime);

        // Resume the movement after a delay
        yield return new WaitForSeconds(resumeTime);

        // Resume the movement
        navMeshAgent.isStopped = false;
    }
}







