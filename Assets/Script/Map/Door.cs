using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    public Transform teleportLocation;
    public TextMeshProUGUI messageText;
    public GameObject[] monsters; // Array to hold references to the monster GameObjects
    private bool isPlayerNear = false;
    public GameObject ActObj;
    private void Start()
    {
        messageText.gameObject.SetActive(false);
        
    }

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
            ActObj.SetActive(true);
        }
    }

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.F))
        {
            // Teleport the player
            Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            playerTransform.position = teleportLocation.position;

                       

            messageText.gameObject.SetActive(false);
        }
    }
}
