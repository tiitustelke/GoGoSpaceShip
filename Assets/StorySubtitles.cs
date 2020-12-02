using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class contains subtitles that are set to textObect for intro story in game.
/// </summary>
public class StorySubtitles : MonoBehaviour
{

    public GameObject textBox;
    public GameObject skip;
    bool storyPlayed = false;

    void Update()
    {

        if (!storyPlayed && PlayerInfo.story)
        {
            playIntro();
            storyPlayed = true;

        }


    }


    void playIntro()
    {
        StartCoroutine("Intro");
    }


    /// <summary>
    /// Method waits before changing text to next line of subtitles
    /// </summary>
    /// <returns></returns>
    IEnumerator Intro()
        {

            yield return new WaitForSeconds(1);
            textBox.GetComponent<Text>().text = "Pilot, you are doing a great job.";
            yield return new WaitForSeconds(3);
            textBox.GetComponent<Text>().text = "With this pace you will reach the destination by tommorow noon.";
            yield return new WaitForSeconds(5);
            textBox.GetComponent<Text>().text = "We won't let anyone stop you from delivering the artifact in time.";
            yield return new WaitForSeconds(5);
            textBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(3);
            textBox.GetComponent<Text>().text = "Oh, no! We detected an anomaly on the radar";
            yield return new WaitForSeconds(4);
            textBox.GetComponent<Text>().text = "Hostiles approaching! Prepare your lasergun.";
            yield return new WaitForSeconds(4);
            textBox.GetComponent<Text>().text = "";
            PlayerInfo.story = false;
            yield break;

        }

}
