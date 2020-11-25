using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float lastUpdate, lastSpawn, multiplier;
    Vector2 min, max;

    private List<Level> levels;

    private int spawnCount, totalSpawns;

    public GameObject[] enemyTypes, bossTypes;

    GameObject boss;

    private Background background;

    // Start is called before the first frame update
    void Start()
    {
        min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));

        levels = new List<Level>
        {
            new Level(2, 3, 30),
            new Level(1, 4, 20)
        };

        lastUpdate = 0;
        lastSpawn = 0;
        spawnCount = 0;
        totalSpawns = 0;

        background = GameObject.Find("Background").GetComponent<Background>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!boss)
        {
            background.SetBgSpeed(2f);
            lastUpdate += Time.deltaTime;
            if (lastUpdate >= levels[PlayerInfo.level].enemySpawnTime)
            {
                if (lastSpawn >= 0.3)
                {
                    if (spawnCount >= levels[PlayerInfo.level].spawnsPerTime)
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
                        int type = UnityEngine.Random.Range(0, PlayerInfo.level + 1);
                        if (type == 1)      //spawn position is further from edges of screen if enemy is of moving type
                        {
                            spawnPosition = new Vector3(max.x, UnityEngine.Random.Range(min.y + 1, max.y - 2.5f));
                        }
                        else
                        {
                            spawnPosition = new Vector3(max.x, UnityEngine.Random.Range(min.y, max.y));
                        }

                        Instantiate(enemyTypes[type], spawnPosition, Quaternion.identity);
                    }
                }
                else
                {
                    lastSpawn += Time.deltaTime;
                }
                if (levels[PlayerInfo.level].maxEnemies == totalSpawns)
                {
                    if (PlayerInfo.level + 1 < levels.Count)
                    {
                        PlayerInfo.level++;
                        totalSpawns = 0;
                    }
                    else
                    {
                        totalSpawns = 0;
                    }
                    Invoke(nameof(SpawnBoss), 2);
                }
            }
        }
    }

    void SpawnBoss()
    {
        int r = UnityEngine.Random.Range(0, 2);
        boss = Instantiate(bossTypes[r], new Vector3(max.x, max.y / 2), bossTypes[r].transform.rotation);
        
        //Boss' health is increased according to current level
        multiplier = 1f + (0.05f * PlayerInfo.level);
        boss.GetComponent<Boss>().health = boss.GetComponent<Boss>().health * multiplier;
        background.SetBgSpeed(0f);
    }
}
