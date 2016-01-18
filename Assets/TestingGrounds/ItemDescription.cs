using UnityEngine;
using System.Collections;

public class ItemDescription : MonoBehaviour {

	[HideInInspector]
	public Material SelectMaterial;
	private Material DefaultMaterial;
	[HideInInspector]
	public bool isChosen;
	public float Price;
	private Vector3 InitLocation;
	private Vector3 InitScale;
	[HideInInspector]
	public Vector3 CloseLocation;

	void Start () 
	{
		InitLocation = transform.localPosition;
		InitScale = transform.localScale;
		DefaultMaterial = gameObject.GetComponent<MeshRenderer>().material;

		print (InitLocation);
			print(InitScale);
	}

	void Update () 
	{
		if(isChosen == true)
		{
			gameObject.GetComponent<MeshRenderer>().material = SelectMaterial;
		}
		else
		{
			gameObject.GetComponent<MeshRenderer>().material = DefaultMaterial;
		}

	}

	public IEnumerator CloseMenu(float AnimationSpeed)
	{
		for(float i = 0f; i*Time.fixedDeltaTime*AnimationSpeed <= 1; i++)
		{
			if(i*Time.fixedDeltaTime*AnimationSpeed > 0.9)	//to make sure the end value is 1
			{
				transform.localPosition = Vector3.Lerp(InitLocation,CloseLocation,1);
				transform.localScale = Vector3.Lerp(InitScale,Vector3.zero,1);
			}
			else
			{
				transform.localPosition = Vector3.Lerp(InitLocation,CloseLocation,i*Time.fixedDeltaTime*AnimationSpeed);
				transform.localScale = Vector3.Lerp(InitScale,Vector3.zero,i*Time.fixedDeltaTime*AnimationSpeed);
			}
			yield return new WaitForSeconds(0.01f);
		}
	}

	public IEnumerator OpenMenu(float AnimationSpeed)
	{
		for(float i = 0f; i*Time.fixedDeltaTime*AnimationSpeed <= 1; i++)
		{
			if(i*Time.fixedDeltaTime*AnimationSpeed > 0.9)
			{
				transform.localPosition = Vector3.Lerp(CloseLocation,InitLocation,1);
				transform.localScale = Vector3.Lerp(Vector3.zero,InitScale,1);
			}
			else
			{
				transform.localPosition = Vector3.Lerp(CloseLocation,InitLocation,i*Time.fixedDeltaTime*AnimationSpeed);
				transform.localScale = Vector3.Lerp(Vector3.zero,InitScale,i*Time.fixedDeltaTime*AnimationSpeed);
			}
			yield return new WaitForSeconds(0.01f);
		}
	}

}
