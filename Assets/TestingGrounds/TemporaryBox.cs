using UnityEngine;
using System.Collections;

public class TemporaryBox : MonoBehaviour {

	public float DeletionDelay;

	void Awake()
	{
		StartCoroutine(DelayedDeletion());
	}

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	IEnumerator DelayedDeletion()
	{
		yield return new WaitForSeconds(DeletionDelay);
		Destroy(gameObject);
	}
}
