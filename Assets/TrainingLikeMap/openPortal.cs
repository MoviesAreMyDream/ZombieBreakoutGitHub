using UnityEngine;
using System.Collections;

public class openPortal : MonoBehaviour {

    private Collider steamCol;
    private GameObject portal;

	// Use this for initialization
	void Start () {

        steamCol = GameObject.Find("SteamCollider").GetComponent<Collider>();
        portal = GameObject.Find("PortalMap");
	}
	
	// Update is called once per frame
	void Update () {
	
        if(steamCol.enabled == false)
        {
            portal.SetActive(true);
        }
	}
}
