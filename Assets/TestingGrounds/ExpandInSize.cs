using UnityEngine;
using System.Collections;

public class ExpandInSize : MonoBehaviour {

	public float DesiredSize = 17;
	[ReadOnlyAttribute]
	public float LerpLocation = 0;
	private Vector3 InitSize;
	public float ExpansionRate = 1f;
	public float GrowDelayRate = 1f;
	public float DelayBeforeDeletion = 1f;
	private bool AlreadyExploded = false;

	private bool Counter;//for DoOnce

	[Space(20)]
	public AudioClip ShrinkSFX;
	
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
		if(Counter == false)
		{
			Counter = true;
			transform.GetComponent<AudioSource>().clip = ShrinkSFX;
			transform.GetComponent<AudioSource>().Play();
		}
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
