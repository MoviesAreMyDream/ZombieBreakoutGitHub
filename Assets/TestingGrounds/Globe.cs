using UnityEngine;
using System.Collections;

public class Globe : MonoBehaviour {

	public float RotationSpeed;
	public float SpinSpeed = 1;

	private bool Idle = true;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	private Quaternion CurrentLocation;
	
	void Update () 
	{
		if(Idle == true)
		transform.Rotate (Vector3.down * RotationSpeed * Time.deltaTime, Space.Self);

		if(Input.GetKey(KeyCode.M))
	   	{
			CurrentLocation = transform.localRotation;
			for(float i = 0f; i*Time.fixedDeltaTime*SpinSpeed <= 1; i++)
			{
				transform.localRotation = transform.localRotation * Quaternion.Lerp(CurrentLocation,Quaternion.Euler(0,90,0),i);
			}
		}

		if(Input.GetKeyDown(KeyCode.N))
		{
			if(!Idle)
			{
				Idle = true;
			}
			else
			{
				Idle= false;
			}
		} 


	}
}
