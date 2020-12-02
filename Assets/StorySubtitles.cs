using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class contains subtitles that are set to textObect for intro story in game.
/// </summary>
public class StorySubtitles : MonoBehaviour
{
    private Text textBox;
    // Start is called before the first frame update
    void Start()
    {
        textBox = GameObject.Find("StoryText").GetComponent<Text>();
        if (PlayerInfo.story)
        {
            playIntro();
        }

    }

    void Update()
    {

    }

    public void playIntro()
        {
            StartCoroutine("Intro");

        }
    IEnumerator Intro()
    {
        yield return new WaitForSeconds(1);
        textBox.text = "Pilot, you are doing a great job.";
        yield return new WaitForSeconds(2);
        textBox.text = "Remember to steer using up and down arrow keys.";
        yield return new WaitForSeconds(4);
        textBox.text = "With this pace you will reach planet Elon by tommorow noon.";
        yield return new WaitForSeconds(2);
        textBox.text = "We won't let anyone stop you from delivering the artifact in time.";
        yield return new WaitForSeconds(2);
        textBox.text = "";
        yield return new WaitForSeconds(2);
        textBox.text = "Oh, oh! We detected an anomaly on the radar";
        yield return new WaitForSeconds(3);
        textBox.text = "Hostiles approaching! Prepare your lasergun!";
        yield return new WaitForSeconds(3);
        textBox.text = "Shoot by pressing the space button!";
        yield return new WaitForSeconds(2);
        textBox.text = "";

        PlayerInfo.story = false;
        yield break;

    }

}
