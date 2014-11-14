using UnityEngine;
using System.Collections;

public class gameCamera : MonoBehaviour {

	private Transform target;
	
	
	public void setTarget(Transform t){
		target = t;
	}

	void LateUpdate(){
		if (target) {
			transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
		}
	}
}
