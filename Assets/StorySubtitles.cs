﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorySubtitles : MonoBehaviour
{
    Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox = GameObject.Find("StoryText").GetComponent<Text>();
        if (PlayerInfo.story)
        {
            PlayIntro();
        }
        
    }

    public void PlayIntro()
    {
        StartCoroutine("Intro");
    }

    IEnumerator Intro()
    {
        //FindObjectOfType<AudioManager>().Play("Intro");
        yield return new WaitForSeconds(1);
        textBox.text = "Pilot, you are doing a great job.";
        yield return new WaitForSeconds(2);
        textBox.text = "With this pace you will reach planet Elon by tommorow noon.";
        yield return new WaitForSeconds(2);
        textBox.text = "We won't let anyone stop you from delivering the artifact in time.";
        yield return new WaitForSeconds(2);
        textBox.text = "";
        yield return new WaitForSeconds(2);
        textBox.text = "Oh, oh! We detected an anomaly on the radar";
        yield return new WaitForSeconds(3);
        textBox.text = "Hostiles approaching! Prepare your lasergun";
        yield return new WaitForSeconds(2);
        textBox.text = "";
        // FindObjectOfType<AudioManager>().Stop("Intro");
        PlayerInfo.story = false;
        yield break;

    }
    
    IEnumerator PreBossOne()
    {
        //FindObjectOfType<AudioManager>().Play("BossOne");
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Something huge is approaching you!";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "This might get a little tricky";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "";
        //FindObjectOfType<AudioManager>().Stop("BossOne");
        yield break;

    }


    IEnumerator PreBossTwo()
    {
        //FindObjectOfType<AudioManager>().Play("BossOne");
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Seems like we got another one of those big ones coming!";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "Prepare to dodge some lasers!";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "";
        //FindObjectOfType<AudioManager>().Stop("BossOne");

        yield break;

    }
}
