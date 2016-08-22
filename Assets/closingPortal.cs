using UnityEngine;
using System.Collections;
using Leap;

public class closingPortal : MonoBehaviour {

    private GameObject player;
    public GameObject leftHand;

	// Use this for initialization
	void Start () {

        player = GameObject.Find("OVRPlayerController");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider hit)
    {
        if(hit.gameObject.tag == "Player" && leftHand.activeSelf == true)
        {
            gameObject.GetComponent<CircularProgressBar>().enabled = true;
        }
    }
}
