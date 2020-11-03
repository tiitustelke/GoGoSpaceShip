﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UfoSpawner : MonoBehaviour
{
    long lastUpdate;
    Vector2 min, max;
    public GameObject ufo;

    // Start is called before the first frame update
    void Start()
    {
        min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
        lastUpdate = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }

    // Update is called once per frame
    void Update()
    {
        if (DateTimeOffset.UtcNow.ToUnixTimeSeconds() - lastUpdate >= 5)
        {
            lastUpdate = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            Instantiate(ufo, new Vector3(max.x, GetRandomPosition(min.y, max.y)), Quaternion.identity);
        }
    }

    private float GetRandomPosition(float min, float max)
    {
        System.Random random = new System.Random();
        return (float)random.NextDouble() * (max - min) + min;
    }
}
