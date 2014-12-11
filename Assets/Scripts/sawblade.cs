using UnityEngine;
using System.Collections;

public class sawblade : MonoBehaviour {
		public float speed = 300;
		
		void OnTriggerEnter(Collider c){
			if (c.tag == "Player") {
			c.GetComponent<Entity>().TakeDamage(10, "slashing");
			}
		}



}
