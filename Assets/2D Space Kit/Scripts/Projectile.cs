using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public GameObject shoot_effect;
	public GameObject hit_effect;
	public GameObject firing_ship;
	float speed = 5f;
	
	// Use this for initialization
	void Start () {
		GameObject obj = (GameObject) Instantiate(shoot_effect, transform.position, Quaternion.identity); //Spawn muzzle flash
		transform.position += Vector3.left * Time.deltaTime * speed;
		Destroy(gameObject, 5f); //Bullet will despawn after 5 seconds
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnCollisionEnter2D(Collision2D col) {

		//Don't want to collide with the ship that's shooting this thing, nor another projectile.
		if (col.gameObject != firing_ship && col.gameObject.tag != "Projectile") {
			Instantiate(hit_effect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
	
	
	
}
