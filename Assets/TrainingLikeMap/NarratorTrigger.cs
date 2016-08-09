using UnityEngine;
using System.Collections;

public class NarratorTrigger : MonoBehaviour {

    public AudioSource narrator;
    public Collider trigger;
    public GameObject helmet;
    public GameObject portal;
    private GameObject player;

    public bool isHelmet;
    public bool isPortal;
    public bool isSkill;

	// Use this for initialization
	void Start () {

        //portal = GameObject.Find("PortalMap");
        player = GameObject.Find("OVRPlayerController");
	}
	
	// Update is called once per frame
	void Update () {
	

	}

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            trigger.enabled = true;
            narrator.Play();
            //Destroy(gameObject);
            gameObject.GetComponent<Collider>().enabled = false;

            if(isHelmet)
            {
                helmet.SetActive(false);

            }

            if(isPortal)
            {
                portal.SetActive(true);
            }

            if(isSkill)
            {
                player.GetComponent<ReverseSkill_Training>().enabled = true;
            }
        }
    }
}
