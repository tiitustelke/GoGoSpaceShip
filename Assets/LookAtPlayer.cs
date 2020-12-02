using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script makes a 2D object face towards the Player
/// </summary>
public class LookAtPlayer : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vectorToTarget = player.transform.position - transform.position;
        float angle2 = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;      //gets angle to player
        Quaternion q = Quaternion.AngleAxis(angle2, Vector3.forward);                               //how much to rotate
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5f);          //rotates toward player
    }
}
