using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionSelectTrigger : MonoBehaviour {

	public GameObject IndicatorReference;
	
	private bool TextActive = false;
	private bool IsInTrigger;

	public AudioClip In;
	public AudioClip Out;


	void Start () 
	{

//		IndicatorReference.SetActive(false);
	
	}

	void Update () {
	
	}

	void OnTriggerEnter(Collider something)
	{
		MissionSelect player = something.GetComponent<MissionSelect>();

		if(something.tag ==  "Player")
		{
			something.GetComponent<AudioSource>().clip = In;
			something.GetComponent<AudioSource>().Play();
			player.CanChoose = true; //this code is actually similar to ShopSelection.cs but it doesn't include the CanChoose variable (too lazy to change lol)
			IndicatorReference.SetActive(true);
//			IndicatorReference.GetComponent<Text>().enabled = true;
//			IndicatorReference.GetComponentInChildren<Image>().enabled = true;
		}
	}
	
	void OnTriggerExit(Collider something)
	{
		MissionSelect ayy = something.GetComponent<MissionSelect>();

		if(something.tag ==  "Player")
		{
			something.GetComponent<AudioSource>().clip = Out;
			something.GetComponent<AudioSource>().Play();
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
