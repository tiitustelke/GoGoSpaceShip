using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private readonly float directionChangeTime = 1f;
    private float latestDirectionTIme;
    public float movementSpeed = 5f;
    private Vector2 movementDirection, movement;
    // Start is called before the first frame update
    void Start()
    {
        
        latestDirectionTIme = 0f;
        //min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        //max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));
    }
    void Update()
    {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        if (camDistance < 10f)
        {
            latestDirectionTIme = Time.time;
            GetNewMovementVector();
        }
        if (Time.time - latestDirectionTIme > directionChangeTime) 
        {
            latestDirectionTIme = Time.time;
            GetNewMovementVector();
        }
        
        transform.position = new Vector2(transform.position.x + (movement.x * Time.deltaTime),
        transform.position.y + (movement.y * Time.deltaTime));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2f, 2f), Mathf.Clamp(transform.position.y, -4f, 4f), transform.position.z);
        //transform.position = movement * maxSpeed * Time.deltaTime;
    }
    void GetNewMovementVector()
    {
        movementDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        movement = movementDirection * movementSpeed;
    }
    private void FixedUpdate()
    {
        
    }

}
