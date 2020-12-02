using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Button playButton, quitButton, settingsButton, scoreButton;
    GameObject mainMenu, settingsMenu, scoresMenu;

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
        quitButton.onClick.AddListener(() => QuitGame());

        settingsButton.onClick.AddListener(() => Settings());
        scoreButton.onClick.AddListener(() => Scores());

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
