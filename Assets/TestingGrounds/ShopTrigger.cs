using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopTrigger : MonoBehaviour {

	public GameObject ShopTextReference;
	public GameObject ShopSelectionReference;

	private bool TextActive = false;
	private bool IsInTrigger;

	public AudioClip In;
	public AudioClip Out;

	private bool Counter;

	void Start () 
	{

	}
	

	void Update ()
	{

		if(TextActive == true)
		{
			Counter = false;
			ShopTextReference.SetActive (true);

		}
		else
		{

			if(!Counter)
			{
				Counter = true;
				ShopTextReference.SetActive(false);
			}
	
		}

		if((Input.GetKeyDown(ShopSelectionReference.GetComponent<ShopSelection>().ShopButton) && IsInTrigger == true) || (Input.GetKeyDown(ShopSelectionReference.GetComponent<ShopSelection>().AlternateShopButton) && IsInTrigger == true))
		{
			if(TextActive == true)
			{
				TextActive = false;
			}
			else
			{
				TextActive = true;
			}
		}


	}

	void OnTriggerEnter(Collider Ayy)
	{
		if(Ayy.tag == "Player")
		{
			Ayy.GetComponent<AudioSource>().clip = In;
			Ayy.GetComponent<AudioSource>().Play();
			TextActive = true;
			Ayy.GetComponent<ShopSelection>().ShopCanOpen = true;
			IsInTrigger = true;
			ShopTextReference.SetActive(true);
//			ShopTextReference.GetComponent<Text>().enabled = true;
//			ShopTextReference.GetComponentInChildren<Image>().enabled = true;
		}
	}

	void OnTriggerExit(Collider Lmao)
	{
		if(Lmao.tag == "Player")
		{
			Lmao.GetComponent<AudioSource>().clip = Out;
			Lmao.GetComponent<AudioSource>().Play();
			TextActive = false;
			Lmao.GetComponent<ShopSelection>().ShopCanOpen = false;
			IsInTrigger = false;
			ShopTextReference.SetActive(false);
//			ShopTextReference.GetComponent<Text>().enabled = false;
//			ShopTextReference.GetComponentInChildren<Image>().enabled = false;

		}
	}

}
