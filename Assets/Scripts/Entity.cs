using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	public float health;
	protected Animator animator;
	public int deathCount=0;

	//damageType määrittelee erilaiset vahinkoluokat, sen avulla päästään käsiksi
	//eri kuolema-animaatioihin. Kolme vaihtoehtoa tällä hetkellä 
	//ovat fire, crushing ja slashing.

	void Start(){

		}

	public void TakeDamage(float dmg, string damageType){
		health -= dmg;

		if (health <= 0 ) {
			Die();
		}
	}

	public void Die(){
		deathCount += 1;
		print (deathCount);
		transform.position = Vector3.zero;
	}
}
