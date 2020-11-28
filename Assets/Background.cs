using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Background class.
/// This class implements moving background.
/// Tutorial and instructions were given by YouTuber MadFireOn on video https://www.youtube.com/watch?v=32EIYs6Z18Q.
/// </summary>
public class Background : MonoBehaviour
{
    public Renderer backgroundRend;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /// <summary>
    /// Moves background left once per frame. If there is a boss enemy spawned, the background is not moving.
    /// </summary>
    void Update()
    {
        float backgroundSpeed = 2;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 1)
        {
            if (enemies[0].GetComponent<Boss>() != null)
            {
                backgroundSpeed = 0;
            }
        }
        backgroundRend.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);      //moves renderers material
    }
}
