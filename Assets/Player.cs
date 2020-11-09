using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float movementSpeed = 4f;
    float health = 100f;
    public GameObject ammo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));
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
            Instantiate(ammo, transform.position + transform.forward * 100, transform.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 50f;
            Destroy(collision.gameObject);
        }
    }
}
