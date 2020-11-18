using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public int enemySpawnTime { get; }
    public int spawnsPerTime { get; }
    public int maxEnemies { get; }

    public Level(int enemySpawnTime, int spawnsPerTime, int maxEnemies)
    {
        this.enemySpawnTime = enemySpawnTime;
        this.spawnsPerTime = spawnsPerTime;
        this.maxEnemies = maxEnemies;
    }

}
