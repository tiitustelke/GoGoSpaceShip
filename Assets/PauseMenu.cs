using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public PauseMenu pauseMenu;
    Button menuButton;
    Button resumeButton;
    Button quitButton;
    /*BUTTONIN PUUTTUU VIELÄ*/
    /*Toimii nyt vaan kun unitysta pause menulle valittu pausemenu*/

    void Start()
    {
        pauseMenu = GameObject.Find("PauseMenu").GetComponent<PauseMenu>();
        menuButton = GameObject.Find("MenuButton").GetComponent<Button>();
        resumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();
        quitButton = GameObject.Find("PauseQuitButton").GetComponent<Button>();

        menuButton.onClick.AddListener(()=> GoToMenu());
        resumeButton.onClick.AddListener(() => Resume());
        quitButton.onClick.AddListener(() => QuitGame());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Debug.Log("Click");
                Resume();
            }
            else
            {
                Debug.Log("Click");
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quit.");
        Application.Quit();
    }

    void GoToMenu()
    {
        Debug.Log("Menu..");
        SceneManager.LoadScene("MainMenu");
    }
}
