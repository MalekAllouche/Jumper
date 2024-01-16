using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 40;
    public GameObject impactEffect;
    public float shootingCooldown = 1f;

    private float timeSinceLastShot = 0f; 

    void Update()
    {
       
        timeSinceLastShot += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && timeSinceLastShot >= shootingCooldown)
        {
            Shoot();
            timeSinceLastShot = 0f; 
        }
    }

    void Shoot()
    {
        Instantiate(impactEffect, firePoint.position, firePoint.rotation);
    }
}
