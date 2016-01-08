using UnityEngine;
using System.Collections;

public class GranadaExplode : MonoBehaviour {

	public GameObject SlowTimeZone;
	public GameObject StopTimeZone;
	public bool StopMode;


	public float GrenadeExpansionRate = 1f;
	public float AreaOfEffectLongevity = 1f;
	public float GrenadeTimer = 2f;
	public float TimeScaling = 0.2f;
	public float ThrowStrength;
	
	// Use this for initialization
	void Start () 
	{
		SlowTimeZone.GetComponent<ExpandInSize>().ExpansionRate = GrenadeExpansionRate;
		StopTimeZone.GetComponent<ExpandInSize>().ExpansionRate = GrenadeExpansionRate;
		SlowTimeZone.GetComponent<ExpandInSize>().DelayBeforeDeletion = AreaOfEffectLongevity;
		StopTimeZone.GetComponent<ExpandInSize>().DelayBeforeDeletion = AreaOfEffectLongevity;
		SlowTimeZone.GetComponent<Chronos.AreaClock3D>().localTimeScale = TimeScaling;
		StopTimeZone.GetComponent<Chronos.AreaClock3D>().localTimeScale = TimeScaling;
	}

	void Awake()
	{
		gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * ThrowStrength);
		StartCoroutine(ExplodeBoom());
	}
	
	// Update is called once per frame
	void Update () 
	{
		//for testing only!
//		SlowTimeZone.GetComponent<ExpandInSize>().ExpansionRate = GrenadeExpansionRate;
//		StopTimeZone.GetComponent<ExpandInSize>().ExpansionRate = GrenadeExpansionRate;
//		SlowTimeZone.GetComponent<ExpandInSize>().DelayBeforeDeletion = AreaOfEffectLongevity;
//		StopTimeZone.GetComponent<ExpandInSize>().DelayBeforeDeletion = AreaOfEffectLongevity;
//		SlowTimeZone.GetComponent<Chronos.AreaClock3D>().localTimeScale = TimeScaling;
//		StopTimeZone.GetComponent<Chronos.AreaClock3D>().localTimeScale = TimeScaling;

//			if (Input.GetKeyDown(KeyCode.X))
//		    {
//				if(StopMode==false)
//				{
//					Instantiate(SlowTimeZone, gameObject.transform.position, Quaternion.identity);
//				}
//				else
//				{
//					Instantiate(StopTimeZone, gameObject.transform.position, Quaternion.identity);
//				}
			}
	
	IEnumerator ExplodeBoom()
		{
		yield return new WaitForSeconds (GrenadeTimer);
		gameObject.GetComponent<MeshRenderer>().enabled = false;
			if(StopMode==false)
				{
					Instantiate(SlowTimeZone, gameObject.transform.position, Quaternion.identity);
				}
					else
				{
					Instantiate(StopTimeZone, gameObject.transform.position, Quaternion.identity);
				}
		Destroy(gameObject);
		}
	
	
}
