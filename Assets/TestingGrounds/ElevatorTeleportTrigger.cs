using UnityEngine;
using System.Collections;

public class ElevatorTeleportTrigger : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter(Collider player)
	{
		if(player.tag == "Player")
		{
			StartCoroutine(Teleport(player));
		}
	}

	void OnTriggerExit(Collider player)
	{
		if(player.tag == "Player")
		{
			
		}
	}

	IEnumerator Teleport(Collider who)
	{
		yield return new WaitForSeconds(3f);

		who.transform.position += new Vector3(0,20,0);
		
	}
}
