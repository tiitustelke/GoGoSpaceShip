using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    Button playButton, quitButton, menuButton;
    GameObject gameOverMenu, InputMenu, goB;
    InputField playerName;

    void Start()
    {
        gameOverMenu = GameObject.Find("GameOverMenu");
        InputMenu = GameObject.Find("InputMenu");

        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        quitButton = GameObject.Find("QuitButton").GetComponent<Button>();
        menuButton = GameObject.Find("MenuButton").GetComponent<Button>();


        playerName = GameObject.Find("UserInput").GetComponent<InputField>();

        //Hide Gameover menu, before it's needed
        gameOverMenu.SetActive(false);

        
         playButton.onClick.AddListener(() => PlayAgain());
         menuButton.onClick.AddListener(() => GoToMenu());
         quitButton.onClick.AddListener(() => QuitGame());
    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Return) && playerName.enabled && playerName.text.Length > 0)
            {
            //Get string from input field
            string playerNameText = playerName.text;

            DataSaver dataSaver = new DataSaver();
            PlayerData playerData = dataSaver.ReadPlayerData();
            Info info = new Info();
            info.Score = PlayerInfo.score;
            dataSaver.SavePlayerData(playerData);
            info.Name = playerName.text;
            playerData.PlayerInfos.Add(info);
            dataSaver.SavePlayerData(playerData);
            playerName.enabled = false;

            Debug.Log(playerNameText);
            playerName.text = "";

            // Disable Input-menu and activate GameOver Menu
            gameOverMenu.SetActive(true);
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
    void GoToMenu()
    {
        Debug.Log("Opening MainMenu....");
        SceneManager.LoadScene("MainMenu");
    }
}
