using UnityEngine;
using System.Collections;

public class littleFlame : MonoBehaviour {

	public float speed = 3;
	public float range = 12;
	private float centre;
	private float right;
	private float left;
	private float dir;
	public PlayerControl apina;
	
	void Start(){
		centre = transform.position.x;
		right = 130;
		left = -66.4394f;
		dir = 1;
	}
	
	void OnTriggerEnter(Collider c){
		if (c.tag == "Player") {
			GameObject joku = GameObject.FindGameObjectsWithTag("Player")[0];
			//joku.animation.Play("tuliKuolema");
			c.GetComponent<Entity>().TakeDamage(10, "slashing");
		}
	}
	
	// Update is called once per frame
	void Update () {
		float p = transform.position.x;
		if (p >= right) {
			p = left;
		}
		Vector3 move = new Vector3 (p + speed * dir * Time.deltaTime, transform.position.y, transform.position.z);
		transform.position = move;
	}
}
