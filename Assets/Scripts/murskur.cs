using UnityEngine;
using System.Collections;

public class murskur : MonoBehaviour {

	/**private BoxCollider collider;
	private float up;
	private float down;
	private float speedDown;
	private float speedUp;
	private float speed;

	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider>();
		speedDown = 15 / 11;
		speedUp = 3.75f;
		up = collider.transform.position.y;
		down = transform.position.y - 12;
	}
	
	// Update is called once per frame
	void Update () {
		float pY = collider.transform.position.y;
		if (pY >= up) {
			speed = speedDown;
		} if (pY <= down) {
			speed = speedDown *(-1);
		}
		
		Vector3 move = new Vector3 (transform.position.x, pY + speed * Time.deltaTime, transform.position.z);
		collider.transform.position = move;
	
	}**/
}
