using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballroll : MonoBehaviour
{
    public float pushForce = 10f; // Adjust the force magnitude as needed
    public float minimumVelocity = 1f; // Minimum velocity for the ball to push the player

    void OnCollisionEnter2D(Collision2D collision)
    {
        ApplyForce(collision);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        ApplyForce(collision);
    }

    private void ApplyForce(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && IsBallRolling())
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                Vector2 forceDirection = collision.transform.position - transform.position;
                forceDirection.y = 0; // Keep the force horizontal if needed
                playerRb.AddForce(forceDirection.normalized * pushForce, ForceMode2D.Impulse);
            }
        }
    }

    private bool IsBallRolling()
    {
        // Check if the ball's velocity is greater than the minimum threshold
        return GetComponent<Rigidbody2D>().velocity.magnitude > minimumVelocity;
    }
}
