using UnityEngine;
using System.Collections;

public class ExpandInSize : MonoBehaviour {

	public float DesiredSize = 17;
	public float LerpLocation = 0;
	private Vector3 InitSize;
	public float ExpansionRate = 1f;
	private float GrowDelayRate = 1f;
	public float DelayBeforeDeletion = 1f;
	private bool AlreadyExploded = false;
	
	void Awake()
	{

	}


	// Use this for initialization
	void Start () 
	{
		InitSize = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.localScale = Vector3.Lerp (InitSize, new Vector3(DesiredSize,DesiredSize,DesiredSize) ,LerpLocation);
		if(AlreadyExploded == false)
		{
			StartCoroutine(Grow());
			if(LerpLocation >= 1)
			{
				AlreadyExploded = true;
			}
		}
		else
		{
			StartCoroutine(Explode());
			if(LerpLocation < 0)
			{
				Destroy(gameObject);
			}
		}

	}

	IEnumerator Shrink()
	{
		LerpLocation -= ExpansionRate/100;
		yield return new WaitForSeconds(GrowDelayRate/10);
	}
	IEnumerator Grow()
	{
		LerpLocation += ExpansionRate/100;
		yield return new WaitForSeconds(GrowDelayRate/10);
	}

	IEnumerator Explode()
	{
		yield return new WaitForSeconds(DelayBeforeDeletion);
		StartCoroutine(Shrink());
	}
}
