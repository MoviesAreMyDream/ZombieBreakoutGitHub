using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwordFOV : MonoBehaviour {

	private vp_FPPlayerEventHandler Player;

	// Use this for initialization
	void Start () {
	
		Player = GameObject.FindObjectOfType (typeof(vp_FPPlayerEventHandler)) as vp_FPPlayerEventHandler;
	}

	void Awake(){


	}


	// Update is called once per frame
	void Update () {

		if(Player.CurrentWeaponName.Get() == "6Sword")
		{
			gameObject.GetComponent<vp_FPCamera>().RenderingFieldOfView = 110;
		}

	}
}


