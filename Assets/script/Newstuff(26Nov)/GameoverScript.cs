using UnityEngine;
using System.Collections;

public class GameoverScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if ((Input.GetButtonDown ("Submit")) || (Input.GetButtonDown ("Fire1")))
			Application.LoadLevel (1);
		if (Input.GetButtonDown("Cancel"))
			Application.LoadLevel(0);
	}
}
