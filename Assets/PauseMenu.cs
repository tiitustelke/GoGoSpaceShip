using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    Button menuButton;
    Button resumeButton;
    Button quitButton;


    void Start()
    {
        /*
         Debug.Log("PauseMenuWorking");
         menuButton = GameObject.Find("MenuButton").GetComponent<Button>();
         resumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();
         quitButton = GameObject.Find("PauseQuitButton").GetComponent<Button>();

         menuButton.onClick.AddListener(delegate { GoToMenu(); });
         resumeButton.onClick.AddListener(() => Resume());
         quitButton.onClick.AddListener(() => QuitGame());
        */
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Debug.Log("Resume game..");
                Resume();
            }
            else
            {
                Debug.Log("Pause game..");
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quit.");
        Application.Quit();
    }

    public void GoToMenu()
    {
        Debug.Log("Menu..");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
