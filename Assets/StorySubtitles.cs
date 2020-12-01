using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorySubtitles : MonoBehaviour
{
    //pitää tehdä boolean jolla saa asetuksista tekstitykset pois.
    public GameObject textBox;
    public static int story = 0;
    // Start is called before the first frame update
    void Start()
    {
      

    }

    void Update()
    {
        if (PlayerInfo.story && story == 0)
        {
            playIntro();
            story++;
           
        }

        if (PlayerInfo.story && story == 1)
        {

        }
    }

    public void playIntro()
        {
            StartCoroutine("Intro");
            
        }
    IEnumerator Intro()
    {
        //FindObjectOfType<AudioManager>().Play("Intro");
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Pilot, you are doing a great job.";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "With this pace you will reach planet Elon by tommorow noon.";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "We won't let anyone stop you from delivering the artifact in time.";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "Oh, oh! We detected an anomaly on the radar";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "Hostiles approaching! Prepare your lasergun";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "";
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
