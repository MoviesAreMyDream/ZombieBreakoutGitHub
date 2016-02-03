using UnityEngine;
using System.Collections;

public class ElevatorDoorTrigger : MonoBehaviour {

	public GameObject AnimatorReference;

	private Animator ElevatorAnim;

	void Start () { 
		ElevatorAnim = AnimatorReference.GetComponent<Animator>();
	}
	
	void Update () {

	}

	void OnTriggerEnter(Collider player)
	{
		if(player.tag == "Player")
		{
			ElevatorAnim.SetBool("Open",true);
		}
	}

	void OnTriggerExit(Collider player)
	{
		if(player.tag == "Player")
		{
			ElevatorAnim.SetBool("Open",false);
		}
	}
}
