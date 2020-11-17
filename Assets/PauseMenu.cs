using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public PauseMenu pauseMenu;

    /*BUTTONIN PUUTTUU VIELÄ*/
    /*Toimii nyt vaan kun unitysta pause menulle valittu pausemenu*/

    void Start()
    {
        pauseMenu = GameObject.Find("PauseMenu").GetComponent<PauseMenu>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Debug.Log("Click");
                Resume();
            }
            else
            {
                Debug.Log("Click");
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
