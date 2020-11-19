using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public GameObject shoot_effect;
	public GameObject hit_effect;
	public GameObject firing_ship;
    readonly float speed = 5f;
	private float dmg;
	
	// Use this for initialization
	void Start () {
		dmg = firing_ship.GetComponent<Enemy>().damage;
		GameObject obj = (GameObject) Instantiate(shoot_effect, transform.position, Quaternion.identity); //Spawn muzzle flash
		
		//Destroy(gameObject, 5f); //Bullet will despawn after 5 seconds
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.left * Time.deltaTime * speed;
	}
	
	
	void OnCollisionEnter2D(Collision2D col) {
		Debug.Log(firing_ship);
		//Don't want to collide with the ship that's shooting this thing, nor another projectile.
		if (col.gameObject.CompareTag("Player")) {
			Debug.Log(firing_ship.GetComponent<Enemy>().damage);
			Instantiate(hit_effect, transform.position, Quaternion.identity);
			col.gameObject.GetComponent<Player>().DecreaseHealth(firing_ship.GetComponent<Enemy>().damage);
			Destroy(gameObject);
		}
	}
	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}


}
