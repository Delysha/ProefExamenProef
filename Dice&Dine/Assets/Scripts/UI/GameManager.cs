using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool isGamePaused = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadStartScreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScreen");
    }

    public void LoadMoveGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void LoadMainGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("The game is shutting down!");
        Application.Quit();
    }

    public bool IsGamePaused()
    {
        return isGamePaused;
    }
}
