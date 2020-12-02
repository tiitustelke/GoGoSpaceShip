using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// HealthSpawner class spawns the health objects.
/// Contains logic to how often a health item can be dropped by dead enemy.
/// </summary>
public class HealthSpawner : MonoBehaviour
{

    public GameObject HealthBuffPreFab;
    float timeSinceLastSpawn;
    bool canSpawn = false;



    // Start is called before the first frame update
    void Start()
    {

    }
    /// <summary>
    /// Update method keeps track of time that has passed from last health drop.
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= 15)
        {
            canSpawn = true;

        }



    }

    /// <summary>
    /// Gets parameter position from dead enemy and Instantiates a health item with a 20 percent chance.
    /// </summary>
    /// <param name="pos"></param>
    public void SpawnHealth(Vector3 pos)
    {
        
        float num = Random.Range(0f, 101f);
        if (num <= 20f && canSpawn)
        {
            Instantiate(HealthBuffPreFab, pos, Quaternion.identity);
            canSpawn = false;
            timeSinceLastSpawn = 0;
        }
        else if(canSpawn && num > 20f)
        {
            
        }
        



    }

 

}