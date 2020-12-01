using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public float enemySpawnTime { get; set; }
    public int spawnsPerTime { get; set; }
    public int maxEnemies { get; set; }

    public Level(int enemySpawnTime, int spawnsPerTime, int maxEnemies)
    {
        this.enemySpawnTime = enemySpawnTime;
        this.spawnsPerTime = spawnsPerTime;
        this.maxEnemies = maxEnemies;
    }

}
