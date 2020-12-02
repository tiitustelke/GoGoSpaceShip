using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]


/// <summary>
/// This class Contains adjustable settings for AudioManager gameObject
/// </summary>
public class Sound
{

    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 2f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;


}
