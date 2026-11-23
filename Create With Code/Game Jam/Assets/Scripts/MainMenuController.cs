using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start the game
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("My Scene");
    }

    // Settings button
    public void OpenSettings()
    {
        Debug.Log("Settings clicked!");
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quit button clicked!");
    }
}