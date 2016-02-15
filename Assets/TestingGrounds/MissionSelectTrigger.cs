using UnityEngine;
using System.Collections;

public class MissionSelectTrigger : MonoBehaviour {

	public GameObject IndicatorReference;
	
	private bool TextActive = false;
	private bool IsInTrigger;

	// Use this for initialization
	void Start () {
		IndicatorReference.SetActive(false);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider something)
	{
		MissionSelect player = something.GetComponent<MissionSelect>();

		if(something.tag ==  "Player")
		{
			player.CanChoose = true; //this code is actually similar to ShopSelection.cs but it doesn't include the CanChoose variable (too lazy to change lol)
			IndicatorReference.SetActive(true);
		}
	}
	
	void OnTriggerExit(Collider something)
	{
		MissionSelect ayy = something.GetComponent<MissionSelect>();

		if(something.tag ==  "Player")
		{
			ayy.CanChoose = false;
			IndicatorReference.SetActive(false);
			ayy.isOpen = false;
			
			for(int i=0;i < ayy.MissionOptions.Length;i++)
			{
				ayy.MissionOptions[i].OptionGameObject.SetActive(false);
			}
		}
	}
}
