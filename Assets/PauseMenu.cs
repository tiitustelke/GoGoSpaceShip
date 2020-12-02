using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;

    /// <summary>
    /// Get Buttons from pause menu and give methods to them.
    /// </summary>
    void Start()
    {
        pauseMenu.SetActive(false);

        Button[] buttons = pauseMenu.GetComponentsInChildren<Button>(true);
        foreach (Button button in buttons)
        {
            switch (button.name)
            {
                case "MenuButton":
                    button.onClick.AddListener(() => GoToMenu());
                    break;
                case "ResumeButton":
                    button.onClick.AddListener(() => Resume());
                    break;
                case "PauseQuitButton":
                    button.onClick.AddListener(() => QuitGame());
                    break;
            }
        }
    }

    /// <summary>
    /// If user presses esc key, open pause menu.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    /// <summary>
    /// Resume the game, inactive pausemenu and put game's time back on.
    /// </summary>
    public void Resume()
    {
        pauseMenu.SetActive(false);
        PlayerInfo.paused = false;
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Pause the game, set pausemenu active via SetActive method and freezing time with Time.timeScale.
    /// </summary>
    public void Pause()
    {
        pauseMenu.SetActive(true);
        PlayerInfo.paused = true;
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Load main menu scene
    /// </summary>
    public void GoToMenu()
    {
        Time.timeScale = 1f;
        PlayerInfo.paused = false;
        SceneManager.LoadScene("MainMenu");
    }

}
