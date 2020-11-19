using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float movementSpeed = 5f;
    float health = 100f;

    Vector2 min, max;

    public GameObject ammo;

    // Start is called before the first frame update
    void Start()
    {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.position.y < max.y)
            {
                transform.position += Vector3.up * Time.deltaTime * movementSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.position.y > min.y)
            {
                transform.position += Vector3.down * Time.deltaTime * movementSpeed;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(ammo, transform.position + transform.up * 0.5f, transform.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DecreaseHealth(collision.gameObject.GetComponent<Enemy>().damage);
            Destroy(collision.gameObject);
        }
        /*else if (collision.gameObject.CompareTag("Projectile"))
        {
            DecreaseHealth
        }*/
    }
    public void DecreaseHealth(float dmg)
    {
        health -= dmg;
        if (health <= 0) // The player is killed, load game over scene
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
