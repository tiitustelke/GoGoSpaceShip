using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    Button backButton;
    GameObject mainMenu, settingsMenu;
    Slider volumeSlider;

    public AudioMixer audioMixer;
    float volumeValue;

    void Start()
    {
        settingsMenu = GameObject.Find("SettingsMenu");
        mainMenu = GameObject.Find("MainMenu");

        backButton = GameObject.Find("BackButton").GetComponent<Button>();

        backButton.onClick.AddListener(() => GoBack());

        volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();

        volumeSlider.onValueChanged.AddListener(delegate { OnValueChanged(); });

    }

    //Go back to main menu - set settings menu off and active menu menu
    public void GoBack()
    {
        Debug.Log("Back to main menu...");
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    //Get volume value from slider
    void OnValueChanged()
    {
        volumeValue = volumeSlider.value * 100;
        Debug.Log(volumeValue);
    }

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("mixervolumename", volumeValue);
    }
    

}
