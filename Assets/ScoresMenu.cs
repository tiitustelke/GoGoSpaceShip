using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresMenu : MonoBehaviour
{

    Button backButton;
    GameObject mainMenu, scoresMenu;
    
   
    void Start()
    {
        scoresMenu = GameObject.Find("ScoresMenu");
        mainMenu = GameObject.Find("MainMenu");

        backButton = GameObject.Find("BackButton2").GetComponent<Button>();

        backButton.onClick.AddListener(() => GoBack());
    }

    //Go back to main menu- set scores menu off and active menu menu
    public void GoBack()
    {
        Debug.Log("Back to main menu...");
        scoresMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
