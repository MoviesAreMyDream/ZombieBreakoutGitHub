using UnityEngine;
using System.Collections;

public class ChangeTimeline : MonoBehaviour {

	public GameObject Timekeeper;
	public float DesiredTimeScale;
	public float AccelerationRate = 1;
	private float InitTimeScale;
	// Use this for initialization
	void Start () 
	{
		InitTimeScale = Timekeeper.GetComponent<Chronos.GlobalClock>().localTimeScale;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.C))
		{
			Timekeeper.GetComponent<Chronos.GlobalClock>().localTimeScale = DesiredTimeScale*AccelerationRate;
		}

		if(Input.GetKeyDown(KeyCode.V))
		{
			Timekeeper.GetComponent<Chronos.GlobalClock>().localTimeScale = InitTimeScale;
		}

	}
}
