using UnityEngine;
using System.Collections;

public class movingPlatform : MonoBehaviour {

	public float speed = 3;
	public float range = 12;
	private float centre;
	private float right;
	private float left;
	private float dir;

	void Start(){
		centre = transform.position.x;
		right = centre + range / 2;
		left = centre - range / 2;
		dir = -1;
	}

	// Update is called once per frame
	void Update () {
		float p = transform.position.x;
		print (p);
		if (p >= right || p <= left) {
			dir = dir * -1;
		}
		Vector3 move = new Vector3 (p + speed * dir * Time.deltaTime, transform.position.y, transform.position.z);
		transform.position = move;
	}
}
