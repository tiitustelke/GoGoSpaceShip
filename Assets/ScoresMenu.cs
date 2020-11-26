using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresMenu : MonoBehaviour
{

    Button backButton;
    MainMenu mainMenu;
    ScoresMenu scoresMenu;

    void Start()
    {
        scoresMenu = GameObject.Find("ScoresMenu").GetComponent<ScoresMenu>();
        mainMenu = GameObject.Find("MainMenu").GetComponent<MainMenu>();

        backButton = GameObject.Find("BackButton2").GetComponent<Button>();

        backButton.onClick.AddListener(() => GoBack());
    }

    public void GoBack()
    {
        Debug.Log("Back to main menu...");
        scoresMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }
}
