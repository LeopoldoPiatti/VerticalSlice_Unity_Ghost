using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostAnimEvent : MonoBehaviour
{
    public Animator ghostAnim;
    public AudioSource ghostAudio;
    public AudioClip ghostAttack;    
    public float animCooldownTime = 2.0f;
    private bool canAttack = true;
    public GameObject attackWave;

    void Start()
    {       
        ghostAnim = GetComponent<Animator>();        
        ghostAudio = GetComponent<AudioSource>();
    }
    public void AnimAttack()
    {
        if (canAttack)
        {
            StartCoroutine(AnimCooldown());
        }
    }
    IEnumerator AnimCooldown()
    {
        GameObject waveInstance = Instantiate(attackWave, transform.position, transform.rotation);
        Destroy(waveInstance, 1.0f);
        canAttack = false;
        ghostAnim.SetBool("Scream", true);
        ghostAudio.PlayOneShot(ghostAttack);
        yield return new WaitForSeconds(animCooldownTime);
        ghostAnim.SetBool("Scream", false);
        canAttack = true;
    }
}