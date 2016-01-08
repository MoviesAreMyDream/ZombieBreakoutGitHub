using UnityEngine;
using System.Collections;

public class ThrowGrenade : MonoBehaviour {

	public GameObject GrenadeReference;
	public bool isStopMode;
	public float ThrowRange;

	// Use this for initialization
	void Start () 
	{

		GrenadeReference.GetComponent<GranadaExplode>().ThrowStrength = ThrowRange;

	}
	
	// Update is called once per frame
	void Update () {

		GrenadeReference.GetComponent<GranadaExplode>().StopMode = isStopMode;
//		GrenadeReference.GetComponent<GranadaExplode>().ThrowStrength = ThrowRange;

		if(Input.GetKeyDown(KeyCode.G))
		{
			Instantiate(GrenadeReference, gameObject.transform.position, Quaternion.identity);
		}
	
	}
}
