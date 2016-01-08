using UnityEngine;
using System.Collections;

public class PortalAppear : MonoBehaviour {

	public GameObject portalreference;
	private GameObject timeReference;

	// Use this for initialization
	void Start () {
	
		portalreference.SetActive (false);
		timeReference = GameObject.Find ("GameManager");

	}
	
	// Update is called once per frame
	void Update () {
	
		if(timeReference.GetComponent<TimeManager>().TimeLeft <= 180)

		{
			portalreference.SetActive (true);
		}
	}
}
