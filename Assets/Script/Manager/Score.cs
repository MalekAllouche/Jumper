using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public Transform playerTransform; 
    private int highScore = 0;
    void Update()
    {
 
        int currentPlayerHeight = Mathf.FloorToInt(playerTransform.position.y);
        if (currentPlayerHeight > highScore)
        {
            UpdateScore(currentPlayerHeight);
        }
    }

    public void UpdateScore(int score)
    {
        highScore = score;
        PlayerPrefs.SetInt("HighScore", highScore);
        UpdateHighScoreText();
    }

    private void UpdateHighScoreText()
    {
  
        highScoreText.text = highScore.ToString();
    }
    public void SaveScore(int score, int index)
    {
        string key = "HighScore" + index; 
        PlayerPrefs.SetInt(key, score);
        PlayerPrefs.Save();
    }
}
