using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Button playButton, quitButton, settingsButton, scoreButton;
    GameObject mainMenu, settingsMenu, scoresMenu;

    /// <summary>
    /// Get all buttons, inactive settings menu and scores menu, and add methods to buttons.
    /// foreach loop gives Back() method to every back button in main menu.
    /// </summary>
    void Start()
    {

        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        quitButton = GameObject.Find("QuitButton").GetComponent<Button>();
        settingsButton = GameObject.Find("SettingsButton").GetComponent<Button>();
        scoreButton = GameObject.Find("ScoreButton").GetComponent<Button>();

        settingsMenu = GameObject.Find("SettingsMenu");
        mainMenu = GameObject.Find("MainMenu");
        scoresMenu = GameObject.Find("ScoresMenu");

        settingsMenu.SetActive(false);
        scoresMenu.SetActive(false);

        playButton.onClick.AddListener(() => PlayGame());
        settingsButton.onClick.AddListener(() => Settings());
        scoreButton.onClick.AddListener(() => Scores());
        quitButton.onClick.AddListener(() => QuitGame());

        Button[] buttons = gameObject.GetComponentsInChildren<Button>(true);
        foreach (Button button in buttons)
        {
            if (button.name.StartsWith("Back"))
            {
                button.onClick.AddListener(() => Back());
            }
        }
    }


    public void PlayGame()
    {
        Debug.Log("Starting Game....");
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// Quit application and save volume values to player prefs with SaveSoundSettings-method.
    /// </summary>
    public void QuitGame()
    {
        //Save audio volume value while quitting.
        SettingsMenu sMenu = new SettingsMenu();
        sMenu.SaveSoundSettings();

        Application.Quit();
    }

    public void Settings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void Scores()
    {
        mainMenu.SetActive(false);
        scoresMenu.SetActive(true);

        DataSaver dataSaver = new DataSaver();
        PlayerData playerData = dataSaver.ReadPlayerData();
        playerData.PlayerInfos.Sort(new HighestScoreFirst());
        Debug.Log(playerData.PlayerInfos.Count);
        string topThree = "";
        for (int i = 0; i < playerData.PlayerInfos.Count; i++)
        {
            if (i < 2)
            {
                topThree += playerData.PlayerInfos[i].Name + "\t\t\t" + playerData.PlayerInfos[i].Score + "\n";
            }
            else
            {
                topThree += playerData.PlayerInfos[i].Name + "\t\t\t" + playerData.PlayerInfos[i].Score;
                break;
            }
        }
        Text scores = GameObject.Find("Scoreboard").GetComponent<Text>();
        scores.text = topThree;
    }

    /// <summary>
    /// Hides / shows Main menu-menus, after checking if player pressed Back button or not
    /// </summary>
    void Back()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.name.EndsWith("Menu"))
            {
                child.gameObject.SetActive(false);
            }
        }
        mainMenu.SetActive(true);
    }

}
