using UnityEngine;
using System.Collections;

public class MissionSelect : MonoBehaviour {

	public int CurrentOption = 1;
	public GameObject[] OptionReferences;

	private bool CanChoose;
	private string[] InitialText;

	// Use this for initialization
	void Start () 
	{
		for(int i=0;i < OptionReferences.Length;i++)
		InitialText[i] = OptionReferences[i].GetComponent<TextMesh>().text;
	}
		
	void Awake()
	{
		for(int i=0;i < OptionReferences.Length;i++)
		{

			OptionReferences[i].SetActive(false);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if(CanChoose == true)
		{
			for(int i=0;i < OptionReferences.Length;i++)
			{
				if(CurrentOption-1 == i)
				{
					print (InitialText[i]);
					OptionReferences[i].GetComponent<TextMesh>().text = ">" + InitialText[i];

				}
				else
				{
					OptionReferences[i].GetComponent<TextMesh>().text = InitialText[i];
				}
			}
		}
	}

	void OnTriggerEnter(Collider something)
	{
		if(something.tag ==  "Player")
		{
			CanChoose = true;
			for(int i=0;i < OptionReferences.Length;i++)
			{
				OptionReferences[i].SetActive(true);
			}
		}
	}

	void OnTriggerExit(Collider something)
	{
		if(something.tag ==  "Player")
		{
			CanChoose = false;
			for(int i=0;i < OptionReferences.Length;i++)
			{
				OptionReferences[i].SetActive(false);
			}
		}
	}
}
