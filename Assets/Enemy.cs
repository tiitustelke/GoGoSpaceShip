using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType type;
    public float movementSpeed;
    public float hitDamage;
    public float health;

    private float movingTime;
    private bool movingUp;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        movingTime = 0;
        movingUp = true;
    }

    // Update is called once per frame
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

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void DecreaseHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            PlayerInfo.score++;
            ParticleSystem explosionEffect = Instantiate(explosion, transform.position, transform.rotation).GetComponent<ParticleSystem>();
            explosionEffect.Play();
            Destroy(gameObject);
        }
    }
}
