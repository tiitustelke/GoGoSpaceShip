using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This script manages spawning of all enemies including bosses. Levels are also managed by this script.
/// See <see cref="Enemy"/>, <see cref="Boss"/>
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    private float lastUpdate, lastSpawn, multiplier;
    Vector2 min, max;

    private List<Level> levels;

    private int spawnCount, totalSpawns, newBoss;

    public GameObject[] enemyTypes, bossTypes;

    public Text level;

    GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
        //levels have the amount of enemies to spawn, enemies to spawn at a time and how much time is between enemy spawns.
        levels = new List<Level>
        {
            new Level(2, 3, 30),
            new Level(2, 3, 30)
        };
        lastUpdate = 0;
        lastSpawn = 0;
        spawnCount = 0;
        newBoss = 0;
        totalSpawns = 0;

        level = GameObject.Find("Level").GetComponent<Text>();
    }

    /// <summary>
    /// In update method the two levels are changed according to mod 2 of the running level number.
    /// More enemies to spawn during the level, at a time are added and time between enemy spawns is shortened.
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        if (!boss && !PlayerInfo.story)
        {
            lastUpdate += Time.deltaTime;
            if (lastUpdate >= levels[PlayerInfo.level % 2].enemySpawnTime)
            {
                if (lastSpawn >= 0.3)
                {
                    if (spawnCount >= levels[PlayerInfo.level % 2].spawnsPerTime)
                    {
                        spawnCount = 0;
                        lastUpdate = 0;
                    }
                    else
                    {
                        spawnCount++;
                        totalSpawns++;
                        lastSpawn = 0;
                        Vector3 spawnPosition;
                        int type = UnityEngine.Random.Range(0, 2);
                        if (type == 1)      //spawn position is further from edges of screen if enemy is of moving type
                        {
                            spawnPosition = new Vector3(max.x, UnityEngine.Random.Range(min.y + 1, max.y - 2.5f));
                        }
                        else
                        {
                            spawnPosition = new Vector3(max.x, UnityEngine.Random.Range(min.y, max.y));
                        }
                        if (!PlayerInfo.story)
                        {
                            Instantiate(enemyTypes[type], spawnPosition, Quaternion.identity);
                        }
                    }
                }
                else
                {
                    lastSpawn += Time.deltaTime;
                }
                if (levels[PlayerInfo.level % 2].maxEnemies == totalSpawns)
                {
                    PlayerInfo.level++;
                    level.text = "Level: " + (PlayerInfo.level + 1).ToString();

                    totalSpawns = 0;
                    lastSpawn -= 2;
                    int mod = PlayerInfo.level % 2;             //counts mod 2 from running level
                    newBoss = mod;                              //boss is selected according the mod
                    levels[mod].spawnsPerTime++;                //more enemies are spawned at a time
                    levels[mod].maxEnemies += 2;                //more enemies are spawned during the level
                    levels[mod].enemySpawnTime -= 0.05f;        //time between the enemy spawns will be slighly lower
                    Invoke(nameof(SpawnBoss), 2);
                    
                    
                }
            }
        }
        
    }
    /// <summary>
    /// Spawns a new boss
    /// </summary>
    void SpawnBoss()
    {

            boss = Instantiate(bossTypes[newBoss], new Vector3(max.x, max.y - ((max.y - min.y) / 2)), bossTypes[newBoss].transform.rotation);

            //Boss' health is increased according to current level
            multiplier = 1f + (0.1f * PlayerInfo.level);
            boss.GetComponent<Boss>().health = boss.GetComponent<Boss>().health * multiplier;    

    }

    

}
