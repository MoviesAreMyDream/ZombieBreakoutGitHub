using UnityEngine;
using System.Collections;


public class PlayerHP : MonoBehaviour {

	public float health = 200;
//	int damage = 50;
		
	public void ApplyDamage (float damage) {

//		health -= damage;
		if (health <= 0)
		Destroy(gameObject);
		print("Hit");

	}

}