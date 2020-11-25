using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Thanks MadFireOn https://www.youtube.com/watch?v=32EIYs6Z18Q
public class Background : MonoBehaviour
{
    public float backGroundSpeed;
    public Renderer backgroundRend;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        backgroundRend.material.mainTextureOffset += new Vector2(backGroundSpeed * Time.deltaTime, 0f);      //moves renderers material
    }

    public void SetBgSpeed(float speed)         //used to set the speed of background movement
    {
        this.backGroundSpeed = speed;
    }
}
