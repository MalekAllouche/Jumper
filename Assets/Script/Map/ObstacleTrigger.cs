using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public GameObject obstacle; // Assign the obstacle object in the Unity Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            if (obstacle != null)
            {
                obstacle.SetActive(false);
                Debug.Log("COLLIDED");
            }
        }

    }
}