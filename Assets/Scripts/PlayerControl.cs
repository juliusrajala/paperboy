using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]

public class PlayerControl : MonoBehaviour {


	public float gravity = 30;
	public float acceleration = 12;
	public float jumpheight = 15;
	public float whileFloating = 20;
	public float speed = 12;
	public float speedWhileFloating = 6;

	private float speedFalling;
	private float gravityNow;
	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;
	
	private PlayerPhysics playerPhysics;
	private Animator animator;

	// Use this for initialization
	void Start () {
		playerPhysics = GetComponent<PlayerPhysics> ();
		animator = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton ("Jump") && Mathf.Sign(amountToMove.y) == -1) {
			gravityNow = whileFloating;
			speedFalling = speedWhileFloating;
		}

		var horizontal = Input.GetAxis ("Horizontal");

		if (horizontal < 0) {
						if (gravityNow == whileFloating) {
								animator.SetInteger ("Direction", 4);
						} else {
								animator.SetInteger ("Direction", 2);
						}
				} else {
						if (gravityNow == whileFloating) {
								animator.SetInteger ("Direction", 3);
						} else {
								animator.SetInteger ("Direction", 1);
						}
				}

		targetSpeed = Input.GetAxisRaw ("Horizontal") * speed;
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
		if (speedFalling != 0) {
						if (amountToMove.y < speedFalling * (-1)) {
								amountToMove.y = speedFalling * (-1);
						}
				}
		playerPhysics.Move (amountToMove * Time.deltaTime);

		gravityNow = gravity;
		speedFalling = 0;

	
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
