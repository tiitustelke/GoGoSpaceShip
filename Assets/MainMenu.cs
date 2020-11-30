using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private Button playButton;
    private Button quitButton;
    private Button settingsButton;
    private Button scoreButton;

    GameObject mainMenu, settingsMenu, scoresMenu;

    void Start()
    {
        playButton = (Button)GameObject.Find("PlayButton").GetComponent<Button>();
        quitButton = (Button)GameObject.Find("QuitButton").GetComponent<Button>();
        settingsButton = (Button)GameObject.Find("SettingsButton").GetComponent<Button>();
        scoreButton = (Button)GameObject.Find("ScoreButton").GetComponent<Button>();

        settingsMenu = GameObject.Find("SettingsMenu");
        mainMenu = GameObject.Find("MainMenu");
        scoresMenu = GameObject.Find("ScoresMenu");

        settingsMenu.SetActive(false);
        scoresMenu.SetActive(false);

        playButton.onClick.AddListener(() => PlayGame());
        quitButton.onClick.AddListener(() => QuitGame());

        settingsButton.onClick.AddListener(() => Settings());
        scoreButton.onClick.AddListener(() => Scores());

    }


    public void PlayGame()
    {
        Debug.Log("Starting Game....");
        SceneManager.LoadScene("Game");
        PauseMenu.GameIsPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quit.");
        Application.Quit();
    }

    public void Settings()
    {
        Debug.Log("Settings...");
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void Scores()
    {
        Debug.Log("Scores....");
        mainMenu.SetActive(false);
        scoresMenu.SetActive(true);
    }

}
