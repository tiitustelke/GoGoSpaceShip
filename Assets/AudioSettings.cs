using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{

    private static readonly string VolumePref = "VolumePref";
    public float volumeValue;

    void Awake()
    {
        ContinueSettings();
    }

    //Load settings from player prefs on startup.
    private void ContinueSettings()
    {
        volumeValue = PlayerPrefs.GetFloat(VolumePref);

        //Set volume to audiolistener to change gameaudio volume
        AudioListener.volume = volumeValue;

        Debug.Log(volumeValue);
    }
        
}
