using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

	public GameObject fireExplosion;

	void Start()
	{}

	void OnTriggerEnter(Collider hit)
	{
//		print("hitting");

		GameObject smoke = GameObject.Instantiate(fireExplosion, transform.position, fireExplosion.transform.rotation) as GameObject;
		GameObject.Destroy(smoke, 2f);
		print("colliding");
	}

	void OnTriggerExit(Collider hit)
	{
		print("out of collider");
		Destroy(this);
	}
}
