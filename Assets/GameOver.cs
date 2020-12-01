﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    
   
    Button playButton;
    Button quitButton;
    Button menuButton;

    InputField playerName;
    GameObject GameOverMenu, InputMenu;
    

    void Start()
    {
        //PauseMenu.GameIsPaused = true;

        playerName = GameObject.Find("UserInput").GetComponent<InputField>();


        GameOverMenu = GameObject.Find("GameOverMenu");
        InputMenu = GameObject.Find("InputMenu");

        quitButton = GameObject.Find("QuitButton").GetComponent<Button>();
        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        menuButton = GameObject.Find("MenuButton").GetComponent<Button>();
        quitButton.onClick.AddListener(() => QuitGame());
        playButton.onClick.AddListener(() => PlayAgain());
        menuButton.onClick.AddListener(() => OpenMenu());

        //Hide Gameover menu, before it's needed
        GameOverMenu.SetActive(false);
    }


    
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Return))
            {
            //Get string from input field
            string playerNameText = playerName.text;

            DataSaver dataSaver = new DataSaver();
            PlayerData playerData = dataSaver.ReadPlayerData();

            dataSaver.SavePlayerData(playerData);

            Debug.Log(playerNameText);

            playerName.text = "";

            // Disable Input-menu and activate GameOver Menu
            GameOverMenu.SetActive(true);
            InputMenu.SetActive(false);
        }
    }

    //Quit Game
    void QuitGame()
    {
        Debug.Log("Quit...");
        Application.Quit();
    }

    //Start new game
    void PlayAgain()
    {
        Debug.Log("Starting New Game....");
        SceneManager.LoadScene("Game");
    }

    // Load menu scene
    void OpenMenu()
    {
        Debug.Log("Opening MainMenu....");
        SceneManager.LoadScene("MainMenu");
    }
}
