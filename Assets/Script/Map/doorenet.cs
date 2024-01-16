using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class doorenet : MonoBehaviour
{
    public Transform teleportLocation;
    public TextMeshProUGUI messageText;
    private bool isPlayerNear = false;
    public GameObject[] monsters;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            messageText.text = "Press F to open door";
            messageText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            messageText.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.F))
        {
            // Teleport the player
            Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            playerTransform.position = teleportLocation.position;

            foreach (var monster in monsters)
            {
                if (monster != null)
                {
                    monster.SetActive(true);
                }
            }
            messageText.gameObject.SetActive(false);
        }
    }
}
