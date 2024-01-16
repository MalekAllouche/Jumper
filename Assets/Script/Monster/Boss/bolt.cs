using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public int damage = 40;
    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        BossHealth1 bossHealth = hitInfo.GetComponent<BossHealth1>();
        if (bossHealth != null)
        {
            bossHealth.TakeDamage(damage);
            // Optionally, destroy the bullet after hitting the boss
            Destroy(gameObject);
        }
    }

}