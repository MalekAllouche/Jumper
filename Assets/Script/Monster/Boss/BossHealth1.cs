using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth1 : MonoBehaviour, ITakeDamage
{
    public int health = 500;
    //public GameObject deathEffect;
    public bool isInvulnerable = false;
    public Animator animator; 
    private bool isDead = false;
    private BossWeapon1 bossWeapon; 
    private Boss_Run1 bossRunScript;
    private void Start()
    {
      
        bossWeapon = GetComponent<BossWeapon1>();
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable || isDead)
            return;

        health -= damage;
        Debug.Log(health);

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        DisableBossActions();
        animator.SetTrigger("Die");
     
        StartCoroutine(DestroyAfterAnimation());
    }

    private void DisableBossActions()
    {
        Boss_Run1 bossRunScript = animator.GetBehaviour<Boss_Run1>();
        if (bossRunScript != null)
        {
            bossRunScript.canRun = false;
        }


        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<BossWeapon1>().enabled = false;

    }

    IEnumerator DestroyAfterAnimation()
    {

        yield return new WaitForSeconds(GetAnimationLength("Die"));
        animator.SetTrigger("Dead");
        gameObject.SetActive(false); 
        yield return new WaitForSeconds(0.5f);
    }

    private float GetAnimationLength(string animationName)
    {
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;
        foreach (AnimationClip clip in ac.animationClips)
        {
            if (clip.name == animationName)
            {
                return clip.length;
            }
        }
        return 0f;
    }
}