using UnityEngine;
using System.Collections;

public class GoToMenu : MonoBehaviour {

	void Awake()
	{
		StartCoroutine (GoToMainMenu());
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator GoToMainMenu()
	{
		yield return new WaitForSeconds(5);
		Application.LoadLevel(0);
	}
}
