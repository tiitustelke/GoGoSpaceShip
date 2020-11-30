using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    private Button menuButton;
    private Button resumeButton;
    private Button quitButton;



    void Start()
    {
       
        Debug.Log("PauseMenuWorking");
        menuButton = GameObject.Find("MenuButton").GetComponent<Button>();
        resumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();
        quitButton = GameObject.Find("PauseQuitButton").GetComponent<Button>();

        menuButton.onClick.AddListener(()=> GoToMenu());
        resumeButton.onClick.AddListener(() => Resume());
        quitButton.onClick.AddListener(() => QuitGame());

        // Hide pause menu on start
        PauseMenuUI.SetActive(false);
    }

    void Update()
    {
        //Activate pause menu with esc-key
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

    //Set time back on and pause menu off
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }

    // Freeze time and activate pause menu
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    //Quit whole application
    public void QuitGame()
    {
        Debug.Log("Quit.");
        Application.Quit();
    }

    //Go back to main menu
    public void GoToMenu()
    {
        Debug.Log("Menu..");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
