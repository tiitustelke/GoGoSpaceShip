using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;


/// <summary>
/// Code is based on tutorial from Brackeys.
/// Credits to Brackeys. Tutorial link: https://www.youtube.com/watch?v=6OT43pvUyfY
/// 
/// Audiomanager class gives AudioManager GameObject an array of sounds that can be modified in inspector.
/// Easy to use sounds when needed by calling to AudioManager classes methods.
/// </summary>
public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

/// <summary>
/// Adds components in inspector for every sound that the array contains.
/// Sound arrays size can be increased in inspector.
/// </summary>
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }



    /// <summary>
    /// When play is called a string with the name of the audioclip is given.
    /// If audioclip with the name of requested one matches, the audioclip is played.
    /// If no match then Debug.LogWarning is given.
    /// Shooting and hitting sounds have been given a randomized pitch to make it less repetitive.
    /// </summary>
    /// <param name="name"></param>
    public void Play(string name)
    {

        this.name = name;
        Sound s = Array.Find(sounds, sound => sound.name == name);

        //If requested audioclips name doesn't match with anything in array
        if (s == null)
        {
            Debug.LogWarning("Sound with name " + name + " is not in audio array in Sounds. HUOM case sensitive");
            return;
        }

        // Pitch randomizer to decrease repetitive sounds.
        if (this.name == "LaserGun")
        {

            s.source.pitch = UnityEngine.Random.Range(0.95f, 1.1f);

        }

        if (this.name == "HitMarker")
        {
            s.source.pitch = UnityEngine.Random.Range(0.85f, 1.2f);
        }

        s.source.Play();
    }

    /// <summary>
    /// Method for stopping an audioclip with certain name. 
    /// If name is not found in sound array, warning is given.
    /// </summary>
    /// <param name="name"></param>
    public void Stop(string name)
    {

        this.name = name;
        Sound s = Array.Find(sounds, sound => sound.name == name);

        //If requested audioclips name doesn't match with anything in array
        if (s == null)
        {
            Debug.LogWarning("Sound with name " + name + " is not in audio array in Sounds. HUOM case sensitive");
            return;
        }


        s.source.Stop();
    }
}


