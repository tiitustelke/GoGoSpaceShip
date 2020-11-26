using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorySubtitles : MonoBehaviour
{
    //pitää tehdä boolean jolla saa asetuksista tekstitykset pois.
    public GameObject textBox;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    public IEnumerator Intro()
    {
        //FindObjectOfType<AudioManager>().Play("IntroClip");
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
        yield break;
    }

    IEnumerator MovingEnemies()
    {
        //FindObjectOfType<AudioManager>().Play("MovingEnemies");
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "These enemies seem to be more agile, be alert.";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "";
        yield break;
    }

    IEnumerator ShootingEnemies()
    {
        //FindObjectOfType<AudioManager>().Play("ShootingEnemies");
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "These hostiles have guns, dont spare them!.";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "";
        yield break;
    }



    IEnumerator PreBoss()
    {
        //FindObjectOfType<AudioManager>().Play("PreBoss");
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Pilot, something huge is approaching you.";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "I.... I don't think it's friendly!";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "";
        yield break;

    }
}
