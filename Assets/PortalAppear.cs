using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PortalAppear : MonoBehaviour {

	public GameObject portalreference;
	private GameObject timeReference;
	public GameObject NarratorUI;


	// Use this for initialization
	void Start () {
	
		portalreference.SetActive (false);
		timeReference = GameObject.Find ("GameManager");
		gameObject.GetComponent<AudioSource>().enabled = false;
		NarratorUI.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
		if(timeReference.GetComponent<TimeManager>().TimeLeft <= 180)

		{
			portalreference.SetActive (true);
			gameObject.GetComponent<AudioSource>().enabled = true;
			NarratorUI.SetActive (true);

		}
	
	}
}
