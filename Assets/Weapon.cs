using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public EnemyType enemyType { get; set; }
    public float speed = 5f;
    public float damage { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        if (enemyType == EnemyType.Boss)
        {
            transform.up = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyType)
        {
            case EnemyType.Boss:
                transform.position += transform.up * speed * Time.deltaTime;
                break;
            default:
                transform.position += Vector3.right * speed * Time.deltaTime;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                collision.gameObject.GetComponent<Player>().DecreaseHealth(damage);
                break;
            default:
                collision.gameObject.GetComponent<Enemy>().DecreaseHealth(damage);
                break;
        }
        Destroy(gameObject);

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
