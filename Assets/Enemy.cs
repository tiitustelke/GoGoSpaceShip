﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The Enemy class.
/// The logic of enemies is implemented in this class.
/// </summary>
public class Enemy : MonoBehaviour
{

    public EnemyType type;
    public float movementSpeed;
    public float hitDamage;
    public float health;

    private float movingTime;
    public bool movingUp, dead = false;

    public GameObject explosion;


    public static Text sc;

    // Start is called before the first frame update
    void Start()
    {
        movingTime = 0;
        movingUp = true;
        sc = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    /// <summary>
    /// Enemy movement logic.
    /// </summary>
    void Update()
    {
        switch (type)
        {
            case EnemyType.Static:
                transform.position += Vector3.left * movementSpeed * Time.deltaTime;
                break;
            case EnemyType.Moving:
                movingTime += Time.deltaTime;
                if (movingTime >= 0.5)
                {
                    movingTime = 0;
                    movingUp = !movingUp;
                }
                transform.position += (movingUp ? new Vector3(-1, 1) : new Vector3(-1, -1)) * movementSpeed * Time.deltaTime;
                break;
        }
    }

    /// <summary>
    /// Destroy the enemy when it becomes inivisible.
    /// </summary>
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Decrase the health of enemy.
    /// If the health gets a value of 0, the enemy is being destroyed among with explosion effect.
    /// </summary>
    /// <param name="damage">The amount of damage to substract from health.</param>
    /// See <see cref="health"/>.
    public void DecreaseHealth(float damage)
    {
        FindObjectOfType<AudioManager>().Play("HitMarker");
        health -= damage;
        if (health <= 0 && !dead)
        {
            dead = true;
            ParticleSystem explosionEffect = Instantiate(explosion, transform.position, transform.rotation).GetComponent<ParticleSystem>();
            explosionEffect.Play();
            Destroy(gameObject);
            PlayerInfo.score++;
            UpdateScore();
            HealthSpawner spwner = GameObject.Find("HealthSpawner").GetComponent<HealthSpawner>();
            spwner.SpawnHealth(transform.position);



        }
    }

    private void UpdateScore()
    {
        sc.text = "Score: " + PlayerInfo.score.ToString();
    }



}
