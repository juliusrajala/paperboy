using UnityEngine;
using System.Collections;

public class elevator : MonoBehaviour {
	
	public float speed = 3;
	public float range = 12;
	private float centre;
	private float up;
	private float down;
	private float dir;
	
	void Start(){
		centre = transform.position.y;
		up = centre + range / 2;
		down = centre - range / 2;
		dir = -1;
	}
	
	// Update is called once per frame
	void Update () {
		float pY = transform.position.y;
		if (pY >= up || pY <= down) {
			dir = dir * -1;
		}
		
		Vector3 move = new Vector3 (transform.position.x, pY + speed * dir * Time.deltaTime, transform.position.z);
		transform.position = move;
	}
}
