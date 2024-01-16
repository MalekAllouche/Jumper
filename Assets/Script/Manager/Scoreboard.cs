using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        int score = PlayerPrefs.GetInt("HighScore", 0); // Default to 0 if not set
        scoreText.text = score.ToString();
    }
}
