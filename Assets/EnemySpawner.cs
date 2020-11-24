using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float lastUpdate, lastSpawn;
    Vector2 min, max;

    private List<Level> levels;

    private int spawnCount, totalSpawns;

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
                        Vector3 spawnPosition = new Vector3(max.x, UnityEngine.Random.Range(min.y, max.y));
                        Instantiate(enemyTypes[UnityEngine.Random.Range(0, PlayerInfo.level + 1)], spawnPosition, Quaternion.identity);
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
        boss = Instantiate(bossTypes[0], new Vector3(max.x, max.y / 2), bossTypes[0].transform.rotation);
    }
}
