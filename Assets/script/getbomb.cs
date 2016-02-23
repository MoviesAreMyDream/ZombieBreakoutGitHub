using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class getbomb : MonoBehaviour {

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
		final.SetActive (false);

        GameManagerGO = GameObject.Find("GameManager");
        ScrManager = GameManagerGO.GetComponent<ScoreManager>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
            ScrManager.GetDynamite();
			goal1.enabled = false;
			goal2.enabled = true;
            GoalTextAnim.Play("GoalTextAnim");
			final.SetActive (true);
			Destroy(gameObject);
		}
	}
}
