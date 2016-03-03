using UnityEngine;
using System.Collections;

public class MissionSelect : MonoBehaviour {

	public int CurrentOption = 1;
	public GameObject MissionSelectTextReference;
	public KeyCode OpenMissionButton;
	public KeyCode AlternateButton;

	[Space(20)]
	public Options[] MissionOptions;

	[HideInInspector]
	public bool CanChoose;

	private string[] InitialText;//this array needs it's size to be set first in order to contain the values in it

	[HideInInspector]
	public bool isOpen;

	// Use this for initialization
	void Start () 
	{
		InitialText = new string[MissionOptions.Length];//to set the size of the array

		for(int i=0;i < MissionOptions.Length;i++)
		InitialText[i] = MissionOptions[i].OptionGameObject.GetComponent<TextMesh>().text;
	}
		
	void Awake()
	{
		for(int i=0;i < MissionOptions.Length;i++)
		{

			MissionOptions[i].OptionGameObject.SetActive(false);
		}
	}

	// Update is called once per frame
	void Update () 
	{
	
		if(CanChoose == true)
		{
			if(Input.GetKeyDown(OpenMissionButton) || Input.GetKeyDown(AlternateButton	))//to open the menu
			{
				if(!isOpen)
				{
					isOpen = true;
					MissionSelectTextReference.SetActive(false);
					gameObject.GetComponent<CharacterController>().enabled = false;
//					gameObject.GetComponent<OVRPlayerController>().enabled = false;

				}
				else
				{
					isOpen = false;
					MissionSelectTextReference.SetActive(true);
					gameObject.GetComponent<CharacterController>().enabled = true;
//					gameObject.GetComponent<OVRPlayerController>().enabled = true;
				}
			}

			if(isOpen == true)
			{
				for(int i=0;i < MissionOptions.Length;i++)//this is to determine the current option
				{
					MissionOptions[i].OptionGameObject.SetActive(true);

					if(CurrentOption-1 == i)
					{
						MissionOptions[i].OptionGameObject.GetComponent<TextMesh>().text = ">" + InitialText[i];
					}
					else
					{
						MissionOptions[i].OptionGameObject.GetComponent<TextMesh>().text = InitialText[i];
					}
				}
			}
			else
			{
				for(int i=0;i < MissionOptions.Length;i++)
				MissionOptions[i].OptionGameObject.SetActive(false);
			}

			if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.JoystickButton5))
			{
				if(CurrentOption < MissionOptions.Length)
				CurrentOption += 1;
			}

			if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.JoystickButton4))
			{
				if(CurrentOption > 1)
					CurrentOption -= 1;
			}

			if((Input.GetKeyDown(KeyCode.LeftShift) && isOpen == true)|| (Input.GetKeyDown (KeyCode.JoystickButton7) && isOpen == true))
			{
				for(int i=0;i < MissionOptions.Length;i++)
				{					
					if(CurrentOption-1 == i)
					{
						if(MissionOptions[i].MapName == null || MissionOptions[i].MapName == "")
						{
							print ("INVALID MAP NAME!");
						}
						else
						{
							Application.LoadLevel(MissionOptions[i].MapName);
						}
					}
				}
			}

		}
	}

	[System.Serializable]
	public class Options
	{
		public GameObject OptionGameObject;
		public string MapName;
	}


}
