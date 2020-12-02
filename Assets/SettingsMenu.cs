using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string VolumePref = "VolumePref";
    private int firstPlayInt;
    private Slider volumeSlider;
    public float volumeValue;

    /// <summary>
    /// <param name= "firstPlayInt"> Used to check if player started the game for first time or not.</param>
    /// If Player plays for first time, set default settings otherwise use already saved settings.
    /// </summary>
    void Start()
    {

        volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
        volumeSlider.onValueChanged.AddListener(delegate { SetVolume(); SaveSoundSettings(); });

        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        // If playing for first time, set these settings.
        if(firstPlayInt == 0)
        {
            volumeValue = 0.25f;
            volumeSlider.value = volumeValue;
            PlayerPrefs.SetFloat(VolumePref, volumeValue);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        //else load volume value from player prefs.
        else
        {
            volumeValue = PlayerPrefs.GetFloat(VolumePref);
            volumeSlider.value = volumeValue;
        }

    }

    
    /// <summary>
    /// Get volume value from volume-slider and set the value to AudioListener, which adjusts all game volumes.
    /// </summary>
    public void SetVolume()
    {
        //Get value from slider, and print it to debuglog.
        volumeValue = volumeSlider.value;

        //Set volume to audiolistener to change gameaudio volume
        AudioListener.volume = volumeValue;
    }

    /// <summary>
    /// Save volume value to player prefs.
    /// </summary>
    public void SaveSoundSettings()
    {
        //Saving volume value to player prefs.
        PlayerPrefs.SetFloat(VolumePref, volumeSlider.value);
    }


}
