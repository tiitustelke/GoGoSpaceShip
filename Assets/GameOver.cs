using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

   
    private Button playButton;
    private Button quitButton;
    private Button menuButton;

    InputField playerName;
    GameObject GameOverMenu, InputMenu;
    

    void Start()
    {
 
        quitButton = GameObject.Find("QuitButton").GetComponent<Button>();
        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        menuButton = GameObject.Find("MenuButton").GetComponent<Button>();
        playerName = GameObject.Find("UserInput").GetComponent<InputField>();
        GameOverMenu = GameObject.Find("GameOverMenu");
        InputMenu = GameObject.Find("InputMenu");

        quitButton.onClick.AddListener(() => Quit());
        playButton.onClick.AddListener(() => PlayAgain());
        menuButton.onClick.AddListener(() => OpenMenu());

        GameOverMenu.gameObject.SetActive(false);
    }


    //Get text from input field
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Return))
            {
            DataSaver dataSaver = new DataSaver();
            PlayerData playerData = dataSaver.ReadPlayerData();

            dataSaver.SavePlayerData(playerData);


            Debug.Log(playerName.text);

            playerName.text = "";
            InputMenu.SetActive(false);
            GameOverMenu.SetActive(true);
        }
    }

    void Quit()
    {
        Debug.Log("Quit...");
        Application.Quit();
    }

    void PlayAgain()
    {
        Debug.Log("Starting New Game....");
        SceneManager.LoadScene("Game");
    }

    void OpenMenu()
    {
        Debug.Log("Opening MainMenu....");
        SceneManager.LoadScene("MainMenu");
    }
}
