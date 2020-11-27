﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This class does the logic for boss movement and shooting.
/// </summary>
public class Boss : Enemy
{
    public GameObject ammo;
    public float fireRate, damage; //firerate: 0.5 = every half second, 2 = every two seconds...
    private GameObject player;
    private float fireTime = 0;     //firetime: how much time until next shot

    Vector3 targetPos, centerPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        centerPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2));
        targetPos = centerPos;
        sc = GameObject.Find("Score").GetComponent<Text>();
    }

    void Update()
    {
        float angle = Random.Range(0, 2 * Mathf.PI);

        if (Vector2.Distance(transform.position, targetPos) < 0.01)
        {
            if (targetPos == centerPos)
            {   //Switches moving behaviour according to boss type
                switch (type)
                {
                    //Target is player on y-axis and moves randomly on x-axis
                    case EnemyType.Miniboss:
                        targetPos = new Vector2(transform.position.x + (Mathf.Cos(angle) * 3), player.transform.position.y);
                        break;
                    //Target random in x and y axis
                    case EnemyType.Boss:
                        targetPos = new Vector2(transform.position.x + (Mathf.Cos(angle) * 3), transform.position.y + (Mathf.Sin(angle) * 3));
                        break;
                }

            }
            else
            {
                targetPos = centerPos;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, Time.deltaTime * 2f);
        //Shoot when time from last firing reaches 0
        if (fireTime <= 0)
        {
            Shoot();
            fireTime = fireRate;
        }
        //Updates time to fireTime
        fireTime -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject enemyAmmo = Instantiate(ammo, transform.position + transform.up * 2.0f, Quaternion.identity);
        enemyAmmo.GetComponent<Weapon>().damage = damage; 
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), enemyAmmo.GetComponent<Collider2D>());
        enemyAmmo.GetComponent<Weapon>().enemyType = EnemyType.Boss;
    }

}
