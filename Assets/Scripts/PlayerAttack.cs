using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public KeyCode attackKey = KeyCode.Space;
    public float cooldownTime = 2.0f;
    public bool canAttack = true;
    public Slider cooldownSlider;
    public GameObject activatedObject; // Objeto a activar cuando se realiza un ataque

    private Collider playerCollider;

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

        // Obtener el Collider del personaje
        playerCollider = GetComponent<Collider>();

        // Desactivar el objeto que se activará al principio
        if (activatedObject != null)
        {
            activatedObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(attackKey) && canAttack)
        {
            StartCoroutine(Attack());
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Attack()
    {
        // Activar el objeto cuando se realiza un ataque
        if (activatedObject != null)
        {
            activatedObject.SetActive(true);
        }

        // Desactivar el collider del personaje directamente
        playerCollider.enabled = false;

        // Iniciar la corrutina para reactivar el collider después del tiempo de invulnerabilidad
        StartCoroutine(ReactivatePlayerColliderAfterCooldown(cooldownTime));

        cooldownSlider.value = 0.0f;
        yield return null;
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

        // Desactivar el objeto nuevamente al final del cooldown
        if (activatedObject != null)
        {
            activatedObject.SetActive(false);
        }
    }

    IEnumerator ReactivatePlayerColliderAfterCooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        playerCollider.enabled = true;
    }
}


//using System.Collections;
//using UnityEngine;
//using UnityEngine.UI;

//public class PlayerAttack : MonoBehaviour
//{
//    public KeyCode attackKey = KeyCode.Space;
//    public float attackRange = 5.0f;
//    public float cooldownTime = 2.0f;
//    public bool canAttack = true;
//    public LayerMask enemyLayer;
//    public Slider cooldownSlider;

//    void Start()
//    {
//        if (cooldownSlider == null)
//        {
//            Debug.LogError("Cooldown Slider not assigned!");
//        }
//        else
//        {
//            cooldownSlider.value = 1.0f;
//        }
//    }

//    private void Update()
//    {
//        if (Input.GetKeyDown(attackKey) && canAttack)
//        {
//            StartCoroutine(Attack());
//            StartCoroutine(Cooldown());
//        }
//    }

//    IEnumerator Attack()
//    {
//        Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

//        foreach (Collider enemyCollider in colliders)
//        {
//            GameObject enemyObject = enemyCollider.gameObject;
//            if (Vector3.Distance(transform.position, enemyObject.transform.position) <= attackRange)
//            {
//                enemyObject.SetActive(false);
//                StartCoroutine(ReactivateEnemyAfterCooldown(enemyObject, cooldownTime));
//            }
//        }

//        cooldownSlider.value = 0.0f;
//        yield return null; // Añadido para evitar advertencias de compilación
//    }

//    IEnumerator Cooldown()
//    {
//        canAttack = false;
//        float elapsedTime = 0.0f;

//        while (elapsedTime < cooldownTime)
//        {
//            cooldownSlider.value = Mathf.Lerp(0.0f, 1.0f, elapsedTime / cooldownTime);
//            elapsedTime += Time.deltaTime;
//            yield return null;
//        }

//        cooldownSlider.value = 1.0f;
//        canAttack = true;
//    }

//    IEnumerator ReactivateEnemyAfterCooldown(GameObject enemyObject, float cooldown)
//    {
//        yield return new WaitForSeconds(cooldown);
//        enemyObject.SetActive(true);
//    }
//}



