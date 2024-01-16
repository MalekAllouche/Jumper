using System.Collections;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    public Sprite redSprite; // Assign the red sprite in the inspector
    private Coroutine changeColorCoroutine = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object is the player and coroutine is not already running
        if (collision.gameObject.CompareTag("Player") && changeColorCoroutine == null)
        {
            changeColorCoroutine = StartCoroutine(ChangeColorAndDestroy());
        }
    }

    private IEnumerator ChangeColorAndDestroy()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(0.5f);

        // Change the sprite to red
        GetComponent<SpriteRenderer>().color = Color.red;

        // Wait for another 1 second
        yield return new WaitForSeconds(0.5f);

        // Make the object invisible or inactive (without deactivating GameObject)
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        // Reactivate the object and reset its color
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = Color.white; // Reset color to white or original color

        changeColorCoroutine = null;
    }
}