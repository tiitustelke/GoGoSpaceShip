using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float lastUpdate, lastSpawn, multiplier;
    Vector2 min, max;

    private List<Level> levels;

    private int spawnCount, totalSpawns, lastLevel;

    public GameObject[] enemyTypes, bossTypes;

    GameObject boss;

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
        lastLevel = 0;
        totalSpawns = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!boss)
        {
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
                    lastLevel = PlayerInfo.level;
                    if (PlayerInfo.level + 1 < levels.Count)
                    {
                        PlayerInfo.level++;
                    }
                    totalSpawns = 0;
                    lastSpawn -= 2;
                    Invoke(nameof(SpawnBoss), 2);
                }
            }
        }
    }

    void SpawnBoss()
    {
        boss = Instantiate(bossTypes[lastLevel], new Vector3(max.x, max.y - ((max.y - min.y) / 2)), bossTypes[lastLevel].transform.rotation);
        
        //Boss' health is increased according to current level
        multiplier = 1f + (0.1f * PlayerInfo.level);
        boss.GetComponent<Boss>().health = boss.GetComponent<Boss>().health * multiplier;
    }
}
