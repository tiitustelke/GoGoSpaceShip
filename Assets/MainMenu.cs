using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Button playButton;
    Button quitButton;
    Button settingsButton;
    Button scoreButton;

    MainMenu mainMenu;
    SettingsMenu settingsMenu;
    ScoresMenu scoresMenu;

    void Start()
    {
        playButton = (Button)GameObject.Find("PlayButton").GetComponent<Button>();
        quitButton = (Button)GameObject.Find("QuitButton").GetComponent<Button>();
        settingsButton = (Button)GameObject.Find("SettingsButton").GetComponent<Button>();
        scoreButton = (Button)GameObject.Find("ScoreButton").GetComponent<Button>();

        settingsMenu = GameObject.Find("SettingsMenu").GetComponent<SettingsMenu>();
        mainMenu = GameObject.Find("MainMenu").GetComponent<MainMenu>();
        scoresMenu = GameObject.Find("ScoresMenu").GetComponent<ScoresMenu>();

        settingsMenu.gameObject.SetActive(false);
        scoresMenu.gameObject.SetActive(false);

        playButton.onClick.AddListener(() => PlayGame());
        quitButton.onClick.AddListener(() => QuitGame());

        settingsButton.onClick.AddListener(() => Settings());
        scoreButton.onClick.AddListener(() => Scores());

    }


    public void PlayGame()
    {
        Debug.Log("Starting Game....");
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Quit.");
        Application.Quit();
    }

    public void Settings()
    {
        Debug.Log("Settings...");
        mainMenu.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(true);
    }

    public void Scores()
    {
        Debug.Log("Scores....");
        mainMenu.gameObject.SetActive(false);
        scoresMenu.gameObject.SetActive(true);
    }

}
