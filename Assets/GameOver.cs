using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

   
    private Button PlayButton;
    private Button QuitButton;
    private Button MenuButton;

    private InputField inputField;
    private GameOver GameOverMenu;
    private GameOver InputMenu;
    private string userName;

    void Start()
    {
 
        QuitButton = GameObject.Find("QuitButton").GetComponent<Button>();
        PlayButton = GameObject.Find("PlayButton").GetComponent<Button>();
        MenuButton = GameObject.Find("MenuButton").GetComponent<Button>();
        inputField = GameObject.Find("UserInput").GetComponent<InputField>();
        GameOverMenu = GameObject.Find("GameOverMenu").GetComponent<GameOver>();
        InputMenu = GameObject.Find("InputMenu").GetComponent<GameOver>();

        QuitButton.onClick.AddListener(() => Quit());
        PlayButton.onClick.AddListener(() => PlayAgain());
        MenuButton.onClick.AddListener(() => OpenMenu());

        GameOverMenu.gameObject.SetActive(false);
    }


    //Get text from input field
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                userName = inputField.text;

                Debug.Log(userName);

                inputField.text = "";
                InputMenu.gameObject.SetActive(false);
                GameOverMenu.gameObject.SetActive(true);
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
