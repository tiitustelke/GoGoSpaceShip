using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class controls how the dropped health object behaves.
/// Heals when collides with palyer & moves on update etc.
/// </summary>
public class HealthBuff : MonoBehaviour
{

    public float speed = 5f;
    public float heal = 20f;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    

    /// <summary>
    /// gameObject moves to the left with the spped of 5f.
    /// </summary>
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    /// <summary>
    /// When the health drop gameObject collides with player --->
    ///     Heals player but not to more than 100 health(checks it with maxHpTest variable).
    /// </summary>

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float maxHpTest = PlayerInfo.health + heal;
            if (maxHpTest > 100f)
            {
                collision.gameObject.GetComponent<Player>().IncreaseHealth(100 - PlayerInfo.health);
                Debug.Log(PlayerInfo.health);
                Destroy(gameObject);
                FindObjectOfType<AudioManager>().Play("HealthPickup");
            }

            else if (maxHpTest < 80f)
            {
                collision.gameObject.GetComponent<Player>().IncreaseHealth(heal);
                Debug.Log(PlayerInfo.health);
                Destroy(gameObject);
                FindObjectOfType<AudioManager>().Play("HealthPickup");
            }
            else if (maxHpTest > 80f && maxHpTest < 101f)
            {
                PlayerInfo.health = 100;
                Debug.Log(PlayerInfo.health);
                Destroy(gameObject);
                FindObjectOfType<AudioManager>().Play("HealthPickup");
            }



        }

        
        
    }
    /// <summary>
    /// When gameObject becomes invisible to player, gameObject gets destroyed.
    /// </summary>
    
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
