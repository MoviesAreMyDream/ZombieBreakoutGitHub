using UnityEngine;
using System.Collections;

public class ShopSelection : MonoBehaviour {

	public Material SelectionMaterial;
	[Space(15)]
	public float Money;
	public GameObject MoneyTextReference;
	[Space(15)]
	public KeyCode ShopButton;
//	public KeyCode CloseShopButton;
	public int OptionSelection = 1;
	private int CurrentSelection;
	[Space(15)]
	public int SelectionWidth;
	public int SelectionHeight;
	[Space(15)]
	public GameObject MainMenuReference;
	private Vector3 MenuCloseLocation;
	public int ShopAnimationSpeed;
	public bool ShopOpen;
	[HideInInspector]
	public bool ShopCanOpen;




	public GameObject[] Contents;

	private Material DefaultMaterial;
	
	void Start () 
	{
		MenuCloseLocation = MainMenuReference.transform.localPosition;

		//To set the material on each of the GameObject so that when they are chosen, their material can be changed properly
		for(int i=0;i < Contents.Length;i++)
		{
		Contents[i].GetComponent<ItemDescription>().SelectMaterial = SelectionMaterial;
		Contents[i].GetComponent<ItemDescription>().CloseLocation = MenuCloseLocation;
		StartCoroutine(Contents[i].GetComponent<ItemDescription>().CloseMenu(50));
		ShopOpen = false;
		}
	}

	void Update () 
	{

		MoneyTextReference.GetComponent<TextMesh>().text = "RM" + Money;

		if(ShopOpen == true)
		{
			//Everything will always be false, except for the ones that is chosen
				for(int i=0;i < Contents.Length;i++)
				{
					if(OptionSelection-1 == i)
					{
						CurrentSelection = i;
						Contents[i].GetComponent<ItemDescription>().isChosen = true;
					}
					else
					{
						Contents[i].GetComponent<ItemDescription>().isChosen = false;
					}
				}

			if(Input.GetKeyDown(KeyCode.LeftArrow))
			   {
					if(OptionSelection % SelectionWidth-1 == 0)
					{
					OptionSelection = OptionSelection;
					}
					else
					{
					OptionSelection -= 1;
					}
				}

			if(Input.GetKeyDown(KeyCode.RightArrow))
			   {
					if(OptionSelection % SelectionWidth == 0)
					{
					OptionSelection = OptionSelection;
					}
					else
					{
					OptionSelection += 1;
					}
				}

			if(Input.GetKeyDown(KeyCode.UpArrow))
			{
				if(OptionSelection <= SelectionWidth)
				{
					OptionSelection = OptionSelection;
				}
				else
				{
					OptionSelection -= SelectionWidth;
				}
			}

			if(Input.GetKeyDown(KeyCode.DownArrow))
			{
				if(OptionSelection >= SelectionWidth*SelectionHeight || OptionSelection > SelectionWidth*SelectionHeight - SelectionWidth)
				{
					OptionSelection = OptionSelection;
				}
				else
				{
					OptionSelection += SelectionWidth;
				}
			}

			if(Input.GetKeyDown(KeyCode.LeftShift))
			{
				if(Money - Contents[CurrentSelection].GetComponent<ItemDescription>().Price < 0)
				{
					print ("INSUFFICIENT FUNDS");
				}
				else
				{
					Money -= Contents[CurrentSelection].GetComponent<ItemDescription>().Price;
				}
			}

		//Open/Close shop menu

		}

		if(Input.GetKeyDown(ShopButton) && ShopCanOpen == true)
		{
			if(ShopOpen == true)
			{
				gameObject.GetComponent<CharacterController>().enabled = true;
				gameObject.GetComponent<OVRPlayerController>().enabled = true;
				for(int i=0;i < Contents.Length;i++)
				{
					StartCoroutine(Contents[i].GetComponent<ItemDescription>().CloseMenu(ShopAnimationSpeed));
					ShopOpen = false;
				}
			}
			else
				if(ShopOpen == false)
				{
					gameObject.GetComponent<CharacterController>().enabled = false;
					gameObject.GetComponent<OVRPlayerController>().enabled = false;
					for(int i=0;i < Contents.Length;i++)
					{
						StartCoroutine(Contents[i].GetComponent<ItemDescription>().OpenMenu(ShopAnimationSpeed));
						ShopOpen = true;
					}
				}
		}
		
//		if(Input.GetKeyDown(CloseShopButton))
//		{
//			if(ShopOpen == false)
//			{
//				for(int i=0;i < Contents.Length;i++)
//				{
//					StartCoroutine(Contents[i].GetComponent<ItemDescription>().OpenMenu(ShopAnimationSpeed));
//					ShopOpen = true;
//				}
//			}
//		}




	}
	
}