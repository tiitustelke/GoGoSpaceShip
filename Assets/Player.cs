using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    readonly float movementSpeed = 4f;

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Test.");
    }
}
