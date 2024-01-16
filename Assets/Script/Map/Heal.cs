using System.Collections;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public GameObject player;
    public Collider2D healCollider;
    public Renderer healRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<PlayerHealth>().AddHealth();
            StartCoroutine(healthCooldown());
            Debug.Log("health++");
        }
    }

    IEnumerator healthCooldown()
    {
        healCollider.enabled = false;
        healRenderer.enabled = false;

        yield return new WaitForSeconds(10f);

        healCollider.enabled = true;
        healRenderer.enabled = true;
    }
}
