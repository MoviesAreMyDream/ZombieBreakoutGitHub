using UnityEngine;
using System.Collections;

public class ForwardDamage : MonoBehaviour {

	public float damage = 1.0f;
	public float maxDistance = 2.2f;
	public LayerMask mask;
	public string methodName = "Damage";

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			RaycastHit hit;
			hit.transform.SendMessageUpwards(methodName, damage, SendMessageOptions.DontRequireReceiver);
		}
	}


	void SendDamage (float damage)
	{
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, maxDistance, mask))
		{
			hit.transform.SendMessage(methodName, damage, SendMessageOptions.DontRequireReceiver);
		}
	}
}
