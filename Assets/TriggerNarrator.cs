using UnityEngine;
using System.Collections;

public class TriggerNarrator : MonoBehaviour {

	public GameObject Trigger;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			Trigger.SetActive (true);
		}
	}
}
