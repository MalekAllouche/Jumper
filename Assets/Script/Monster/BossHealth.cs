using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour, ITakeDamage
{
    public int health = 100;
    public GameObject deathEffect;
    public bool isInvulnerable = false;
    public Animator animator; // Reference to the Animator component
    private bool isDead = false;
    public void TakeDamage(int damage)
    {
        if (isInvulnerable || isDead)
            return;

        health -= damage;
        Debug.Log("Monster Health: " + health);

        if (health <= 0 && !isDead)
        {
            Die();
            Destroy(gameObject);
        }
    }

    public void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");
        GetComponent<BossWeapon>().enabled = false;
        GetComponent<Boss>().enabled = false;

        StartCoroutine(DestroyAfterAnimation());
    }

    IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}