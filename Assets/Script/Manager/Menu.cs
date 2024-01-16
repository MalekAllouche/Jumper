using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Settings;
    public void StartGame()
    {
        Debug.Log("Game opened");
        SceneManager.LoadScene("Game");
    }

    public void OpenSettings()
    {

        Debug.Log("Settings opened");
        SceneManager.LoadScene("Settings");
    }
    public void OpenSettingsInGame()
    {

        Debug.Log("Settings opened");
        Settings.SetActive(true);
    }
    public void CloseSettingsInGame()
    {

        Debug.Log("Settings opened");
        Settings.SetActive(false);
    }

    public void OpenScoreboard()
    {

        Debug.Log("Scoreboard opened");
        SceneManager.LoadScene("Scoreboard");
    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Back to Menu opened");
    }
    public void ExitGame()
    {
    
        Application.Quit();
        Debug.Log("Game exited"); 
    }
}