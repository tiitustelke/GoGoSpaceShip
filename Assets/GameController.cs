using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    Button playButton, statsButton, quitButton;

    // Start is called before the first frame update
    void Start()
    {
        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        playButton.onClick.AddListener(() => ClickPlayButton());

        statsButton = GameObject.Find("StatsButton").GetComponent<Button>();
        statsButton.onClick.AddListener(() => ClickStatsButton());

        quitButton = GameObject.Find("QuitButton").GetComponent<Button>();
        quitButton.onClick.AddListener(() => ClickQuitButton());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClickPlayButton()
    {
        Debug.Log("Play clicked.");
        SceneManager.LoadScene("Game");
    }

    void ClickStatsButton()
    {

    }

    void ClickQuitButton()
    {
        Debug.Log("Quit clicked");
        Application.Quit();
    }
}
