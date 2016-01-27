using UnityEngine;
using System.Collections;

public class InnerGlobeFX : MonoBehaviour {

	public float MinValue;
	public float MaxValue;

	[Space(20)]
	public float AnimationSpeed;

	[ReadOnlyAttribute]
	public float EmissiveValue;


	private float Counter;
	private bool GoDown = false;
	
	void Start () {
	
	}

	void Update () {

		gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor",Color.cyan *Mathf.LinearToGammaSpace(EmissiveValue));

		EmissiveValue = Mathf.Lerp(MinValue,MaxValue,Counter);

		if(Counter >= MaxValue)
			GoDown = true;
		else
			if(Counter <= MinValue)
				GoDown = false;

		if(GoDown == false)
			{
				Counter += Time.deltaTime * AnimationSpeed;
			}
		else
		if(GoDown == true)
			{
				Counter -= Time.deltaTime * AnimationSpeed;
			}

	}
}
