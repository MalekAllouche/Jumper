using UnityEngine;

public class bosslevel : MonoBehaviour
{
    public GameObject parentObject; // Parent object containing the monsters as children
    public GameObject door;         // The door object to enable
    
    void Update()
    {
        // Check if there are no more children (monsters) under the parent object
        if (parentObject.transform.childCount == 0)
        {
            door.SetActive(true);
        }
    }
}