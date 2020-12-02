using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{

    private static readonly string VolumePref = "VolumePref";
    public float volumeValue;

    /// <summary>
    /// Do ContinueSettings method on startup
    /// </summary>
    void Awake()
    {
        ContinueSettings();
    }

    /// <summary>
    /// Load volume settings from player prefs on startup, and adjust AudioListener volume.
    /// </summary>
    private void ContinueSettings()
    {
        volumeValue = PlayerPrefs.GetFloat(VolumePref);

        //Set volume to audiolistener to change gameaudio volume
        AudioListener.volume = volumeValue;
    }
        
}
