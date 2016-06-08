using UnityEngine;
using System.Collections;

public class windowManager : MonoBehaviour {

	public GameObject scoreBoard;

	// Use this for initialization
	void Start () {
		//scoreBoard = GameObject.Find ("scoreBoardPanel");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			scoreBoard.SetActive(!scoreBoard.activeSelf);
		}
	}
}
