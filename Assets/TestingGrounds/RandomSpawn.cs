using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class RandomSpawn : MonoBehaviour {

//	public GameObject SpawnedObject;
//	public SpawnLocation[] SpawnLocations;

	public int HowMany;
	public NumOfArray[] List;

	private int Counter = 0;
	private int RandomNum;
	void Start () 
	{
	  
	}


	void Update () 
	{
		print (Counter);

		for(int i = 0 ; i < List.Length; i++)
		{
			RandomNum =  Random.Range(0,List.Length-1);
			List[i].Content = i;
		}

//		foreach(SpawnLocation SpawnBox in SpawnLocations)
//		{
//			if(SpawnBox.boxAlreadySpawned == false)
//			{
//				SpawnBox.boxAlreadySpawned = true;
//				GameObject Mark = (GameObject) Instantiate(SpawnedObject,SpawnBox.Location,Quaternion.identity);
//				Mark.transform.parent = transform;
//			}
//		}
	}

//	[System.Serializable]
//	public class SpawnLocation
//	{
//		public Vector3 Location;
//
//		[HideInInspector]
//		public bool boxAlreadySpawned = false;
//	}

	[System.Serializable]
	public class NumOfArray
	{
		public int Content;

		[HideInInspector]
		public bool AlreadyChosen;
	}
}
