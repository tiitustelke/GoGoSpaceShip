using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    InputField playerName;
    GameObject inputMenu, gameOverMenu;

    void Start()
    {
        playerName = GameObject.Find("UserInput").GetComponent<InputField>();

        foreach (Transform child in transform)
        {
            string objectName = child.gameObject.name;
            if (objectName.EndsWith("Menu"))
            {
                switch (objectName)
                {
                    case "InputMenu":
                        inputMenu = child.gameObject;
                        break;
                    case "GameOverMenu":
                        gameOverMenu = child.gameObject;
                        Button[] buttons = gameOverMenu.GetComponentsInChildren<Button>();
                        foreach (Button button in buttons)
                        {
                            switch (button.name)
                            {
                                case "QuitButton":
                                    button.onClick.AddListener(() => QuitGame());
                                    break;
                                case "PlayButton":
                                    button.onClick.AddListener(() => PlayAgain());
                                    break;
                                case "MenuButton":
                                    button.onClick.AddListener(() => OpenMenu());
                                    break;
                            }
                        }
                        break;
                }
            }
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && playerName.text.Length > 0)
        {
            DataSaver dataSaver = new DataSaver();
            PlayerData playerData = dataSaver.ReadPlayerData();
            Info info = new Info
            {
                Name = playerName.text,
                Score = PlayerInfo.score
            };
            playerData.PlayerInfos.Add(info);
            dataSaver.SavePlayerData(playerData);

            // Disable Input-menu and activate GameOver Menu
            inputMenu.SetActive(false);
            gameOverMenu.SetActive(true);
        }
    }

    //Quit Game
    void QuitGame()
    {
        Application.Quit();
    }

    //Start new game
    void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    // Load menu scene
    void OpenMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
