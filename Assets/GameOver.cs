using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    InputField playerName;
    GameObject inputMenu, gameOverMenu;

    /// <summary>
    /// <param name = "objectName"> Used to get InputMenu and GameOverMenu and Buttons from them </param>
    /// playerName gets text from User input.
    /// </summary>
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


    /// <summary>
    /// If player presses enter, and text input is not empty > save name and score to playerData.
    /// </summary>
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


    void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Start new game
    /// </summary>
    void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// Load main menu scene
    /// </summary>
    void OpenMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
