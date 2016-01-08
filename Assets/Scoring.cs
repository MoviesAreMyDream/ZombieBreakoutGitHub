using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scoring : MonoBehaviour {

	public static Text score;
	public static int scoring;

	// Use this for initialization
	void Start () {
		scoring = 0;
		SetScore ();

	}
	// Update is called once per frame
	//void OnTringgerEnter (Collider other) {
	//	if (other.gameObject.tag == "Zombie") {
	//		scoring = scoring + 1;
	//		EnemyZombie.Death 
	//	}
	//}

	void SetScore()
	{
		score.text = "Zombie Kill: " + scoring.ToString();
		
		}
}
