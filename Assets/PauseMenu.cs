using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    void Start()
    {
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

    public void Resume()
    {
        pauseMenu.SetActive(false);
        PlayerInfo.paused = false;
        Time.timeScale = 1f;
        
    }

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

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        PlayerInfo.paused = false;
        SceneManager.LoadScene("MainMenu");
    }
}
