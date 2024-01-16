using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public AudioSource musicSource; // Assign your AudioSource here
    public Sprite musicOnSprite;    // Assign your 'music on' sprite here
    public Sprite musicOffSprite;   // Assign your 'music off' sprite here

    private bool isMusicOn = true;
    private Image buttonImage;      // Image component of the button

    void Start()
    {
        buttonImage = GetComponent<Image>();
        UpdateButtonSprite();
    }

    public void ToggleMusic()
    {
        isMusicOn = !isMusicOn;
        musicSource.mute = !isMusicOn;
        UpdateButtonSprite();
    }

    private void UpdateButtonSprite()
    {
        buttonImage.sprite = isMusicOn ? musicOnSprite : musicOffSprite;
    }
}
