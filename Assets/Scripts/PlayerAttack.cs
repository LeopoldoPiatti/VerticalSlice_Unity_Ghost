using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public KeyCode attackKey = KeyCode.Space;
    public float radius;
    public float cooldownTime = 2.0f;
    public bool canAttack = true;
    public LayerMask enemyLayer;
    public EnemyPeople enemyMovement;
    public Slider cooldownSlider;

    void Start()
    {       
        if (cooldownSlider == null)
        {
            Debug.LogError("Cooldown Slider not assigned!");
        }
        else
        {
            cooldownSlider.value = 1.0f;
        }
    }

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
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, enemyLayer);
        foreach (Collider nearbyObjects in colliders)
        {
            NavMeshAgent navMeshAgent = nearbyObjects.GetComponent<NavMeshAgent>();
            if (navMeshAgent != null)
            {
                enemyMovement.Flee();
            }
        }
        cooldownSlider.value = 0.0f;
    }

    IEnumerator Cooldown()
    {
        canAttack = false;
        float elapsedTime = 0.0f;
        while (elapsedTime < cooldownTime)
        {            
            cooldownSlider.value = Mathf.Lerp(0.0f, 1.0f, elapsedTime / cooldownTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }       
        cooldownSlider.value = 1.0f;
        canAttack = true;
    }
}