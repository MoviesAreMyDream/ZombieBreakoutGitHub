using UnityEngine;
using System.Collections;

public class finish : MonoBehaviour {

	public string MapName;

	void Start () {
	
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			Application.LoadLevel(MapName);
		}
	}
}
