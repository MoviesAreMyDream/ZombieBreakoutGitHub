using UnityEngine;
using System.Collections;

public class TimeWarpVFX : MonoBehaviour {

	public GameObject CenterEyeAnchor;
	public float LerpDelay;
	public float LerpAcceleration = 10;
	public float Intensity = -10;
	public float ChromaticAberration = 10;

	void Start () {
		
	}

	void OnTriggerEnter (Collider TimeGrenade)
	{
		if(TimeGrenade.tag == "TimeGrenade")
		{
			//StartCoroutine(LerpFX(true));
			CenterEyeAnchor.GetComponent<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration>().enabled = true;
		}

	}

//	IEnumerator LerpFX(bool EnterOrExit)
//	{
//		if(EnterOrExit == true)
//		{
//			for(float i=0f; i <= 10; i++)
//			{
//				yield return new WaitForSeconds(LerpDelay);
//				CenterEyeAnchor.GetComponent<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration>().intensity = Mathf.Lerp(0,Intensity,i/LerpAcceleration);
//				CenterEyeAnchor.GetComponent<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration>().chromaticAberration = Mathf.Lerp (0,ChromaticAberration,i/LerpAcceleration);
//			}
//		}
//		else
//		{
//			for(float i=0f; i <= 10; i++)
//			{
//				yield return new WaitForSeconds(LerpDelay);
//				CenterEyeAnchor.GetComponent<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration>().intensity = Mathf.Lerp(Intensity,0,i/LerpAcceleration);
//				CenterEyeAnchor.GetComponent<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration>().chromaticAberration = Mathf.Lerp (ChromaticAberration,0,i/LerpAcceleration);
//			}
//		}
//	}

	void OnTriggerExit (Collider TimeGranada)
	{

		if(TimeGranada.tag == "TimeGrenade")
		{
			//StartCoroutine(LerpFX(false));
			CenterEyeAnchor.GetComponent<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration>().enabled = false;

		}
	}
	
//	void Update () {
//
//		if(Input.inputString != "")
//		print (Input.inputString);
//	
//	}
}
