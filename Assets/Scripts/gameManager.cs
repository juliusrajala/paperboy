using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	public GameObject player;
	private gameCamera cam;
	
	// Use this for initialization
	void Start () {
		cam = GetComponent<gameCamera>();
		spawnPlayer();
	}

	private void spawnPlayer(){
		cam.setTarget((Instantiate (player, Vector3.zero, Quaternion.identity)as GameObject).transform);
	}


}
