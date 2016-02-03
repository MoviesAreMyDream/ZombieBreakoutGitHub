 using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour {

	[ReadOnlyAttribute]
	public string CurrentTime;
	private float TimeFloat;

	public GameObject Star;
	public int StarMaxParticles;
	public float StarAppearanceTime;

	[Tooltip("Must not be 0 !")]
	public int StarDisappearingRate = 1;
	public float StarDisappearingSpeed;

	private float Counter;
	private bool CanDelete = false;

	public DayNightTrigger[] DayLightZombieTrigger;

	public GameObject ZombieA;

	void Start () 
	{

	}
	
	void Awake()
	{

	}

	void Update () 
	{

//		transform.Rotate(new Vector3(0,CycleSpeed*Time.deltaTime));
		//no need this because there's AutoIntensity to rotate the sun

		TimeFloat = 24 - ((transform.localRotation.eulerAngles.x)/90)*6;
		CurrentTime = TimeFloat.ToString("0.00");

		for(int i = 0; i < DayLightZombieTrigger.Length; i++)
		{
			if(TimeFloat >= DayLightZombieTrigger[i].StartEffectAt && DayLightZombieTrigger[i].StartEffectAt + DayLightZombieTrigger[i].EffectDuration >= TimeFloat)
			{
				print(DayLightZombieTrigger[i].SayWhat);

			}
		}

		if(TimeFloat >= StarAppearanceTime)
		{
			Star.GetComponent<ParticleSystem>().maxParticles = StarMaxParticles;
			CanDelete = true;
		}
		else
		{
			if(CanDelete)
			DeleteStars();
		}
	}

	[System.Serializable]//this is to make the array show up in the inspector
	public class DayNightTrigger
	{
		public float StartEffectAt;
		public float EffectDuration;
		public string SayWhat;

	}

	void DeleteStars()
	{
		if(Counter >= StarDisappearingRate)
		{
			if(Star.GetComponent<ParticleSystem>().maxParticles > 0)
			{
				Star.GetComponent<ParticleSystem>().maxParticles = Star.GetComponent<ParticleSystem>().maxParticles - StarDisappearingRate;
				Counter = 0;
			}
			else
			{
				CanDelete = false;
			}
		}
		else
		{
			Counter += StarDisappearingSpeed*Time.fixedDeltaTime;
		}
	}
}
