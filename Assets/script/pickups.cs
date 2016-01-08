using UnityEngine;
using System.Collections;

public class pickups : MonoBehaviour {

	public AudioSource pickup;

	void OnTriggerEnter(Collider drown) {
		if (drown.gameObject.tag == "Player") {
			PlayerHealthNewChar health = drown.GetComponent<PlayerHealthNewChar>();
			pickup.Play();
			Destroy(gameObject);
			
			if (health != null) {
				health.add(20);	
				//Debug.Log("Player is drowning");
			}
		}
	}
}
