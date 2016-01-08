using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnTempBox : MonoBehaviour {

//	public float DelayBetweenSpawning = 1f;
	public float DeletionTime = 1f;
	public GameObject TempBox;

	void Awake()
	{

	}

	void Start () 
	{
		TempBox.GetComponent<TemporaryBox>().DeletionDelay = DeletionTime;
	}
	

	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Z))
			SpawnBox();
	}

	public void SpawnBox()
	{
		Instantiate(TempBox, gameObject.transform.position, Quaternion.identity);
	}
}
