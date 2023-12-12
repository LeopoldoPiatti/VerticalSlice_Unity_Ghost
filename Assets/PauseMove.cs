using System.Collections;
using UnityEngine;

public class PauseMove : MonoBehaviour
{
    public KeyCode attackKey = KeyCode.Space;
    public float cooldownTime = 2.0f;
    public bool canAttack = true;

    public PlayerMovement scriptToDisable;
    //public GhostAnimations scriptToDisable1;

    void Start()
    {             
        scriptToDisable = GetComponent<PlayerMovement>();
        //scriptToDisable1 = GetComponent<GhostAnimations>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(attackKey) && canAttack)
        {
            Attack();
        }
    }

    void Attack()
    {
        // Desactivar el script durante el ataque
        if (scriptToDisable != null)
        {
            scriptToDisable.enabled = false;
            //scriptToDisable1.enabled = false;
        }        
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        canAttack = false;

        // Lógica para el tiempo de espera
        yield return new WaitForSeconds(cooldownTime);
        
        if (scriptToDisable != null)
        {
            scriptToDisable.enabled = true;
            //scriptToDisable1.enabled = true;
        }

        canAttack = true;
    }
}
