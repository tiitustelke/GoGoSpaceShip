using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;

//Credits Brackeys tutorial: https://www.youtube.com/watch?v=6OT43pvUyfY
public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            Debug.Log(s.source);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }




    public void Play(string name)
    {

        this.name = name;
        Sound s = Array.Find(sounds, sound => sound.name == name);

        //jos paramteri ei matchaa audion nimeen tulee vikailmotusta
        if (s == null)
        {
            Debug.LogWarning("Sound with name " + name + " is not in audio array in Sounds. HUOM case sensitive");
            return;
        }

        // Äänet saa vähän eri pitchiä niin ei aina samallainen.
        if (this.name == "LaserGun")
        {

            s.source.pitch = UnityEngine.Random.Range(0.95f, 1.1f);
            Debug.Log(s.source.pitch.ToString());

        }

        if (this.name == "HitMarker")
        {
            s.source.pitch = UnityEngine.Random.Range(0.85f, 1.2f);
            Debug.Log(s.source.pitch.ToString());
        }

        s.source.Play();
    }


    public void Stop(string name)
    {
        this.name = name;
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Stop();
    }
}


