using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	public Transform Target;
	// Use this for initialization
	void LateUpdate ()
	{
			transform.position = new Vector3 (Target.position.x, transform.position.y, Target.position.z);
			
	}
}
