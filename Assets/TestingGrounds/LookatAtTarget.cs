using UnityEngine;
using System.Collections;

public class LookatAtTarget : MonoBehaviour {

	public Transform Target;
	public bool FlashLightMode = false;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.LookAt(Target);

		if(FlashLightMode == true)
		{
			if(Input.GetKeyDown(KeyCode.F))
			{
				if(gameObject.GetComponent<Light>().isActiveAndEnabled)
				{
					gameObject.GetComponent<Light>().enabled = false;
				}
				else
				{
					gameObject.GetComponent<Light>().enabled = true;
				}
			}
		}
	}
}
