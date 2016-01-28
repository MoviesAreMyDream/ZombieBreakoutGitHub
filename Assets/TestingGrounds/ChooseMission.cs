using UnityEngine;
using System.Collections;

public class ChooseMission : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider something)
	{
		if(something.tag ==  "Player")
		{

		}
	}
}
