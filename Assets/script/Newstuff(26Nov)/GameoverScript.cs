using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameoverScript : MonoBehaviour {

    public string toGameOver;
    public string toRestart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if ((Input.GetButtonDown ("Submit")) || (Input.GetButtonDown ("Fire1")))
			SceneManager.LoadScene(toGameOver);
		if (Input.GetButtonDown("Cancel"))
			SceneManager.LoadScene(toRestart);
	}
}
