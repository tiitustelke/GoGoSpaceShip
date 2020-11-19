using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    private readonly float directionChangeTime = 3f;
    private float latestDirectionTIme;
    //public float movementSpeed = 5f;
    private Vector2 movementDirection, movement;
    public GameObject ammo;
    public float fireRate;
    private float fireTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        latestDirectionTIme = 0f;
        //min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        //max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));
    }
    void Update()
    {
        /*float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        if (camDistance < 10f)
        {
            latestDirectionTIme = Time.time;
            GetNewMovementVector();
        }*/
        if (Time.time - latestDirectionTIme > directionChangeTime) 
        {
            latestDirectionTIme = Time.time;
            GetNewMovementVector();
        } /*else if (transform.position.x < 2f)
        {
            transform.position += Vector3.right * Time.deltaTime * movementSpeed;
        }*/
        
        transform.position = new Vector2(transform.position.x + (movement.x * Time.deltaTime),
        transform.position.y + (movement.y * Time.deltaTime));
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2f, 2f), Mathf.Clamp(transform.position.y, -2f, 2f), transform.position.z);
        fireTime += Time.deltaTime;
        switch (type)
        {
            case EnemyType.Boss:
                //Debug.Log(fireTime);
                if ((fireRate - fireTime) < 0)
                {
                    Debug.Log("Testi");
                    Shoot();
                    fireTime = 0;
                }
                //Debug.Log("testi2");
                break;
        }
        //transform.position = movement * maxSpeed * Time.deltaTime;
    }
    void GetNewMovementVector()
    {
        if (transform.position.x < 2f)
        {
            movementDirection = Vector3.right;
        }
        else if (transform.position.x > 7f)
        {
            movementDirection = Vector3.left;
        }
        else if (transform.position.y > 3.2f)
        {
            movementDirection = Vector3.down;
        }
        else if (transform.position.y < -3.2f)
        {
            movementDirection = Vector3.up;
        }
        else
        {
            movementDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }
        
        movement = movementDirection * movementSpeed;
    }
    void Shoot()
    {
        Debug.Log("Boss shooting");
        Instantiate(ammo, transform.position + transform.forward * 100, transform.rotation);
    }
    private void FixedUpdate()
    {
        
    }

}
