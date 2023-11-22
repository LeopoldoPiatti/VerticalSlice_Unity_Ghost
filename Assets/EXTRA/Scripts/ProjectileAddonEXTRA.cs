using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddonEXTRA : MonoBehaviour
{
    public float delay;
    public float radius;
    public float force;
    float countdown;
    bool hasExploded = false;

    public int damage;

    private Rigidbody rb;

    private bool targetHit;

    public GameObject granadeExplosion;

    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
        countdown = delay;
    }

    private void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded) {
            Explode();
            hasExploded = true; 
        }
    }

    void  Explode ()
    {
        Instantiate(granadeExplosion, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObjects in colliders) 
        {
        Rigidbody rb = nearbyObjects.GetComponent<Rigidbody>();
        if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        Destroy(gameObject);
    }



    private void OnCollisionEnter(Collision collision)
    {
        // check if you hit an enemy
        if (collision.gameObject.GetComponent<BasicEnemyEXTRA>() != null)
        {
            BasicEnemyEXTRA enemy = collision.gameObject.GetComponent<BasicEnemyEXTRA>();

            enemy.TakeDamage(damage);
                       
        }
    }
}