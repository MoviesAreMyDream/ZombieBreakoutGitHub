using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

	public int WaitTime = 1;
	public GameObject progress;
	private float counter = 1f;
//	public GameObject portal; 

	// Use this for initialization
	void Start () {
	
		counter = 0;
		progress.GetComponent<Scrollbar> ().size = 0;
		progress.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetButton("Fire3"))
		{
			if(Mathf.FloorToInt(counter) < WaitTime)
			{
				counter += 1 * Time.deltaTime;
				print(Mathf.FloorToInt(counter));
				progress.GetComponent<Scrollbar>().size = counter / WaitTime;
				progress.SetActive(true);
//				Destroy(portal);
			}
		}
		
		else
			if(Input.GetButtonUp("Fire3"))
		{
			counter = 0;
			progress.SetActive (false);
		}
	}
}
