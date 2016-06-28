using UnityEngine;
using System.Collections;

public class NarratorDialogue : MonoBehaviour {

	public GameObject Text1;
	public GameObject Text2;
	public GameObject Text3;
	public GameObject Text4;
	public GameObject Text5;
	public GameObject Text6;
	public GameObject Text7;

	public GameObject door;

	// Use this for initialization
	void Start () {

       

		Text1.SetActive (true);
		Text2.SetActive (false);
		Text3.SetActive (false);
		//Text4.SetActive (false);
		//Text5.SetActive (false);
		//Text6.SetActive (false);
		//Text7.SetActive (false);

		StartCoroutine (Dialogue());

	}
	
	// Update is called once per frame
	void Update () {
        /*FirstPersonController getMoveDir = GetComponent<FirstPersonController>();
        otherScript.DoSomething();*/

    }

	IEnumerator Dialogue()
	{
		yield return new WaitForSeconds (3f);
		Text1.SetActive (false);
		Text2.SetActive (true);
		yield return new WaitForSeconds (4f);
		Text2.SetActive (false);
		Text3.SetActive (true);
		/*yield return new WaitForSeconds (6f);
		Text3.SetActive (false);
		Text4.SetActive (true);
		yield return new WaitForSeconds (6f);
		Text4.SetActive (false);
		Text5.SetActive (true);
		yield return new WaitForSeconds (6f);
		Text5.SetActive (false);
		Text6.SetActive (true);
		yield return new WaitForSeconds (6f);
		Text6.SetActive (false);
		Text7.SetActive (true);
		yield return new WaitForSeconds (4f);
		Text7.SetActive (false);
		door.GetComponent<BoxCollider> ().enabled = true;*/
	}


}
