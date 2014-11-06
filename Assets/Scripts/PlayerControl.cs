using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]

public class PlayerControl : MonoBehaviour {


	public float gravity = 20;
	public float speed = 10;
	public float acceleration = 12;
	public float jumpheight = 15;
	public float whileFloating = 2;
	private float speedWhileFloating = 5;

	private float speedNow;
	private float gravityNow;
	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;
	
	private PlayerPhysics playerPhysics;

	// Use this for initialization
	void Start () {
		playerPhysics = GetComponent<PlayerPhysics> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton ("Jump") && Mathf.Sign(amountToMove.y) == -1) {
			gravityNow = whileFloating;
			speedNow = speedWhileFloating;
		}

		targetSpeed = Input.GetAxisRaw ("Horizontal") * speedNow;
		currentSpeed = IncrementTowards (currentSpeed, targetSpeed, acceleration);

		if (playerPhysics.grounded) {
			amountToMove.y = 0;
			//Jump
			if(Input.GetButtonDown("Jump")){
				amountToMove.y = jumpheight;
			}
		}

		amountToMove.x = currentSpeed;
		

		amountToMove.y -= gravityNow * Time.deltaTime;
		playerPhysics.Move (amountToMove * Time.deltaTime);

		gravityNow = gravity;
		speedNow = speed;

	
	}

	private float IncrementTowards(float n, float target, float a){
		if(n == target){
			return n;
		}
		else{
			float dir = Mathf.Sign(target-n);
			n+=a*Time.deltaTime*dir;
			return(dir == Mathf.Sign(target-n))? n: target;
		}
	}

}
