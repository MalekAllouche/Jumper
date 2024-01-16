using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int health = 50;
    //public GameObject deathEffect;
    public TMP_Text HP;

    private void Start()
    {
        UpdateHealthDisplay(); 
    }

    public void AddHealth()
    {
        health = 100;
        UpdateHealthDisplay();
        Debug.Log(health);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateHealthDisplay(); 
        Debug.Log(health);
        StartCoroutine(DamageAnimation());

        if (health <= 0)
        {
            Die();
        }
    }

    void UpdateHealthDisplay() 
    {
        HP.text = health.ToString();
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator DamageAnimation()
    {
        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < 3; i++)
        {
            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 0;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);

            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 1;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);
        }
    }
}

