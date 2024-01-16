using UnityEngine;

public class ESC : MonoBehaviour
{
    public GameObject canvas;
    public GameObject otherCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Only toggle canvas if the other canvas is not active
            if (!otherCanvas.activeSelf)
            {
                canvas.SetActive(!canvas.activeSelf);
            }
        }
    }
}
