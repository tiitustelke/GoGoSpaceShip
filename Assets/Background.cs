using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Thanks MadFireOn https://www.youtube.com/watch?v=32EIYs6Z18Q
public class Background : MonoBehaviour
{
    public Renderer backgroundRend;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
