using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PressHOLD : MonoBehaviour {

	public int WaitTime = 1;
	private float DownTime;
	private bool isHandled = false;
	public GameObject portal;
	public Text portalkey;
	public Image Bbut;

	public GameObject homeportal;
	public GameObject progress;

	public Text goal1;
	public Text goal2;
	public GameObject final;
	public Animation GoalTextAnim;

	public GameObject GameManagerGO;
	public ScoreManager ScrManager;
	
	// Use this for initialization
	void Start () {
	
		goal1.enabled = true;
		goal2.enabled = false;
		portalkey.enabled = false;
		Bbut.enabled = false;
		final.SetActive (false);
		homeportal.SetActive (false);

        GameManagerGO = GameObject.Find("GameManager");
        ScrManager = GameManagerGO.GetComponent<ScoreManager>();

		gameObject.GetComponent<ProgressBar>().enabled = false;

//		counter = 0;

//		progress.GetComponent<Scrollbar>().size = 0;
//		progress.SetActive (false);
	}


	// Update is called once per frame
	void OnTriggerStay (Collider portalcol) {
	
		if (portalcol.gameObject.tag == "Portal") {

			portalkey.enabled = true;
			Bbut.enabled = true;
			gameObject.GetComponent<ProgressBar> ().enabled = true;

			if (Input.GetButtonDown ("Fire3")) { //Key was pressed down, so take up time.
				DownTime = Time.time;
				isHandled = false;

//				progress.SetActive (true);

			}
			if (Input.GetButton ("Fire3")) { // is key still being hold down...  
				// And is it been hold over the time we want and is not handled yet?
				if ((Time.time > DownTime + WaitTime)) {
					// We've been here, don't do this again until button is pressed again.
					isHandled = true;
					// Do Something here
					Debug.Log ("Key \"B\" was pressed over " + WaitTime + " seconds.");
//					portal.SetActive (false);
					ScrManager.GetDynamite ();
					goal1.enabled = false;
					goal2.enabled = true;
					GoalTextAnim.Play ("GoalTextAnim");
					final.SetActive (true);
					portalkey.enabled = false;
					Bbut.enabled = false;
					//Destroy (gameObject);
					homeportal.SetActive (true);
					Destroy(portal);
				}

			}

//			Debug.Log("Portal");

		}

		else 
			if(gameObject.GetComponent<ProgressBar>() != null)
		{
			gameObject.GetComponent<ProgressBar>().enabled = false;
			progress.SetActive (false);
		}

	}

//	private float counter = 1f;

	void Update()
	{

	}

//	void ProgressBar()
//	{
//		if(Input.GetButton("Fire3"))
//		{
//			if(Mathf.FloorToInt(counter) < WaitTime)
//			{
//				counter += 1 * Time.deltaTime;
//				print(Mathf.FloorToInt(counter));
//				progress.GetComponent<Scrollbar>().size = counter / WaitTime;
//				progress.SetActive(true);
//			}
//		}
//		
//		else
//			if(Input.GetButtonUp("Fire3"))
//		{
//			counter = 0;
//			progress.SetActive (false);
//		}
//	}


	void OnTriggerExit ()
	{
		portalkey.enabled = false;
		Bbut.enabled = false;

		if(gameObject.GetComponent<ProgressBar>() != null)
		gameObject.GetComponent<ProgressBar>().enabled = false;
//		progress.SetActive (false);
	}


}
