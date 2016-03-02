using UnityEngine;
using System.Collections;

public class InventoryCarrier : MonoBehaviour {

	[SerializeField]
	private GameObject PlayerReference; 

	private vp_Inventory PlayerInventoryReference;

	public vp_ItemType[] PlayerInventory;

	void Start () 
	{
		DontDestroyOnLoad(this);
	}

	void OnLevelWasLoaded(int level)//this function will run when a new level is loaded
	{
		PlayerReference = GameObject.Find("PlayerOVR");
		PlayerInventoryReference = PlayerReference.GetComponent<vp_Inventory>();

		for(int i = 0; i < PlayerInventory.Length;i++)
		{
			if(PlayerInventory[i] != null)
			PlayerInventoryReference.TryGiveItem(PlayerInventory[i],1);
		}
	}
		
	void Update () 
	{
		
	}
}
