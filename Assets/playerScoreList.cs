using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerScoreList : MonoBehaviour {

	public GameObject playerScoreEntryPrefab;

	scoreManager getScoreManager;

	int lastChangeCounter;

	// Use this for initialization
	void Start () {
		getScoreManager = GameObject.FindObjectOfType<scoreManager> ();

		lastChangeCounter = getScoreManager.getChangeCounter ();

		getScoreManager.changeScore ("ME", "scores", 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (getScoreManager == null) {
			Debug.LogError("failed");
			return;
		}

		if (getScoreManager.getChangeCounter () == lastChangeCounter) {
			return;
		}

		lastChangeCounter = getScoreManager.getChangeCounter ();

		while (this.transform.childCount > 0) {
			Transform c = this.transform.GetChild(0);
			c.SetParent(null);
			Destroy (c.gameObject);
		}
		
		string[] names = getScoreManager.getPlayerNames ("kills");
		
		//for (int i=0; i < 5; i++) {
		foreach(string name in names) {
			GameObject go = (GameObject)Instantiate(playerScoreEntryPrefab);
			go.transform.SetParent(this.transform, false);
            go.transform.Find("username").GetComponent<Text>().text = name;
			go.transform.Find("killCount").GetComponent<Text>().text = getScoreManager.getScore(name, "kills").ToString();
			go.transform.Find("scoreCount").GetComponent<Text>().text = getScoreManager.getScore(name, "scores").ToString();
		}
	}
}
