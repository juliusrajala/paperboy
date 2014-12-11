using UnityEngine;
using System.Collections;

public class murskur : MonoBehaviour {
	/*
	
	SpeedUp oli ennen 5
	 */
	private float speedDown;
	private float speedUp;
	public float range = 12;
	private float speed;
	private float centre;
	private float up;
	private float down;
	private float dir;
	
	void Start(){
		centre = transform.position.y;
		up = centre+0.1f;
		down = centre - range;
		dir = -1;
		speedDown = range * (15 / 12);
		speedUp = range * (15 / 4);
		speed = speedDown;
	}
	
	// Update is called once per frame
	void Update () {
		float pY = transform.position.y;
		if (pY >= up) {
						dir = -1;
				} else if (pY <= down) {
						dir = 1;
				}
			if(dir < 0){
				speed = speedDown;
			}
			else{
				speed = speedUp;
			}

		
		Vector3 move = new Vector3 (transform.position.x, pY + speed * dir * Time.deltaTime, transform.position.z);
		transform.position = move;
	}
}
