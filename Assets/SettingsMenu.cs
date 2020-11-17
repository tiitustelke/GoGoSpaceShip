using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    Button backButton;
    MainMenu mainMenu;
    SettingsMenu settingsMenu;
    Slider volumeSlider;

 
    void Start()
    {
        settingsMenu = GameObject.Find("SettingsMenu").GetComponent<SettingsMenu>();
        mainMenu = GameObject.Find("MainMenu").GetComponent<MainMenu>();

        backButton = GameObject.Find("BackButton").GetComponent<Button>();

        backButton.onClick.AddListener(() => GoBack());

        volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();

        volumeSlider.onValueChanged.AddListener(delegate { OnValueChanged(); });
    }

    public void GoBack()
    {
        Debug.Log("Back to main menu...");
        mainMenu.gameObject.SetActive(true);
        settingsMenu.gameObject.SetActive(false);
    }

    void OnValueChanged()
    {
        float volumeValue = volumeSlider.value * 100;
        Debug.Log(volumeValue);
    }

    

}
