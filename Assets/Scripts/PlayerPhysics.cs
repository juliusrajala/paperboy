using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class PlayerPhysics : MonoBehaviour {

	public LayerMask collisionMask;

	private BoxCollider collider;
	private Vector3 s;
	private Vector3 c;

	private float skin =.005f;

	[HideInInspector]
	public bool grounded;
	[HideInInspector]
	public bool movementStopped;

	Ray ray;
	RaycastHit hit;

	//MovingPlatform-settiä

	private Transform movingPlatform;
	private Vector3 platformWas;
	private Vector3 deltaPlatform;


	private bool died;
	public bool boatOnWater;


	void Start (){
		collider = GetComponent<BoxCollider> ();
		s = collider.size;
		c = collider.center;
		died = false;
	}

	public void Move(Vector2 moveAmount){


		float deltaY = moveAmount.y;
		float deltaX = moveAmount.x;
		Vector2 p = transform.position;

		if (movingPlatform) {
						deltaPlatform = movingPlatform.position - platformWas;
						platformWas = movingPlatform.position;
			if(movingPlatform.name == "ConveyorRight"){
				deltaPlatform = new Vector3(3 * Time.deltaTime, 0, 0);
			}
			if(movingPlatform.name == "ConveyorLeft"){
				deltaPlatform = new Vector3(-3 * Time.deltaTime, 0, 0);
			}
		} else {
			deltaPlatform = Vector3.zero;
		}

		grounded = false;
		for (int i = 0; i<3; i++) {
			float dir = Mathf.Sign(deltaY);
			float x = (p.x + c.x - s.x/2)+s.x/2*i;
			float y = p.y+c.y+s.y/2*dir;


			ray = new Ray(new Vector2(x,y), new Vector2(0,dir));
			//Debug.DrawRay(ray.origin, ray.direction);


			//Seuraa collisionia ja toteuttaa laskeutumisen esimerkiksi liikkuville alustoille
			if(Physics.Raycast(ray, out hit, Mathf.Abs(deltaY) + skin,collisionMask)){

				string hitter = hit.transform.parent.name;
				//print (hitter);
				//Checks the ground on wether or not it's water.
				if(hitter.Equals ("Water")){
					boatOnWater = true;
				}

				movingPlatform = hit.transform;
				platformWas = movingPlatform.position;

				//print (movingPlatform.parent.name);


				float dst = Vector3.Distance (ray.origin, hit.point);
				
				if(dst > skin){
					deltaY = dst * dir - skin * dir;
				}
				else{
					deltaY = 0;
				}
				grounded = true;

				
				break;
			}
			else{
				movingPlatform = null;
			}
		}


		//Left and right collission

		movementStopped = false;
		for (int i = 0; i<3; i++) {
			float dir = Mathf.Sign(deltaX);
			float x = p.x + c.x + s.x/2*dir;
			float y = p.y+c.y-s.y/2 + s.y/2*i;
			
			ray = new Ray(new Vector2(x,y), new Vector2(dir, 0));
			//Debug.DrawRay(ray.origin, ray.direction);
			
			if(Physics.Raycast(ray, out hit, Mathf.Abs(deltaX) + skin ,collisionMask)){
				float dst = Vector3.Distance (ray.origin, hit.point);

				string hitter = hit.transform.parent.name;

				if(hitter.Equals("Enemies")){
					GameObject joku = GameObject.FindGameObjectsWithTag("Player")[0];
					joku.GetComponent<Entity>().TakeDamage(10, "slashing");
				}

				if(dst > skin){
					deltaX = dst * dir - skin * dir;
				}
				else{
					deltaX = 0;
				}
				movementStopped = true;


				break;
			}
			
			
		}

		if (!grounded && !movementStopped) {
						Vector3 playerDir = new Vector3 (deltaX, deltaY);
						Vector3 cornerOut = new Vector3 (p.x + c.x + s.x / 2 * Mathf.Sign (deltaX), p.y + c.y + s.y / 2 * Mathf.Sign (deltaY));
						ray = new Ray (cornerOut, playerDir.normalized);


						if (Physics.Raycast (ray, Mathf.Sqrt (deltaX * deltaX + deltaY * deltaY), collisionMask)) {
								grounded = true;
								deltaY = 0;
						}
				}
	

		Vector2 finalTransform = new Vector2 (deltaX + deltaPlatform.x, deltaY + deltaPlatform.y);


		transform.Translate (finalTransform);

	}



}
