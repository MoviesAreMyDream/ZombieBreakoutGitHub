using UnityEngine;
using System.Collections;

public class FlickeringLight : MonoBehaviour {

	public float minFlickerSpeed = 0.1f;
	public float maxFlickerSpeed = 1.0f;

	private Light LightReference;
	private bool Counter;

	void Start()
	{
		LightReference = gameObject.GetComponent<Light>();
	}
	
	void Update()
	{
		if(Counter == false)
		StartCoroutine(Flicker());
	}
	
	IEnumerator Flicker()
	 {
		Counter = true;
		LightReference.enabled = true;
		yield return new WaitForSeconds (Random.Range(minFlickerSpeed, maxFlickerSpeed));
		LightReference.enabled = false;
		yield return new WaitForSeconds (Random.Range(minFlickerSpeed, maxFlickerSpeed));
		Counter = false;
	}
}
