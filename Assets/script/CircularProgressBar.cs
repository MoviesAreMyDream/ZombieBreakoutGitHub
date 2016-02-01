using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CircularProgressBar : MonoBehaviour {

	public int WaitTime = 1;
	public GameObject progress;
	public GameObject progressBG;
	private float counter = 1f;
//	public GameObject portal; 

	// Use this for initialization
	void Start () {
	
		counter = 0;
		progress.GetComponent<Image> ().fillAmount = 0;
//		progress.SetActive (false);
		progressBG.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetButton("Fire3"))
		{
			if(Mathf.FloorToInt(counter) < WaitTime)
			{
				counter += 1 * Time.deltaTime;
				print(Mathf.FloorToInt(counter));
				progress.GetComponent<Image>().fillAmount = counter / WaitTime;
//				progress.SetActive(true);
				progressBG.SetActive(true);
//				Destroy(portal);
			}
		}
		
		else
			if(Input.GetButtonUp("Fire3"))
		{
			counter = 0;
//			progress.SetActive (false);
			progressBG.SetActive(false);
		}
	}
}
