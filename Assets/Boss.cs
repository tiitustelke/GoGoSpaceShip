using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public GameObject ammo;
    public float fireRate;
    private GameObject player;
    float fireTime = 0;

    Vector3 targetPos, centerPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        centerPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2));
        targetPos = centerPos;
    }

    void Update()
    {
        player = GameObject.Find("Player");
        float angle = Random.Range(0, 2 * Mathf.PI);

        if (Vector2.Distance(transform.position, targetPos) < 0.01)
        {
            if (targetPos == centerPos)
            {
                switch (type)
                {
                    case EnemyType.Miniboss:
                        targetPos = new Vector2(transform.position.x + (Mathf.Cos(angle) * 3), player.transform.position.y);
                        break;
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
        if (fireTime <= 0)
        {
            Shoot();
            fireTime = fireRate;
        }
        fireTime -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject enemyAmmo = Instantiate(ammo, transform.position + transform.up * 2.0f, Quaternion.identity);
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), enemyAmmo.GetComponent<Collider2D>());
        enemyAmmo.GetComponent<Weapon>().enemyType = EnemyType.Boss;
    }

}
