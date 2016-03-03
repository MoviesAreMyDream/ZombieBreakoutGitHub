using UnityEngine;
using System.Collections;

public class InventoryCarrier : MonoBehaviour {

	[SerializeField]
	private GameObject PlayerReference; 

	private vp_Inventory PlayerInventoryReference;

	public vp_ItemType[] PlayerInventory;

	public float Money;
	public GameObject MoneyReference;

	void Awake()
	{
		DontDestroyOnLoad(this);

	}

	void Start () 
	{

	}

	void OnLevelWasLoaded(int level)//this function will run when a new level is loaded
	{
		PlayerReference = GameObject.Find("PlayerOVR");
		PlayerInventoryReference = PlayerReference.GetComponent<vp_Inventory>();

		MoneyReference = GameObject.Find("GameManager");

		for(int i = 0; i < PlayerInventory.Length;i++)
		{
			if(PlayerInventory[i] != null)
			PlayerInventoryReference.TryGiveItem(PlayerInventory[i],1);
		}

		if(level == 1)
		{
			Money = MoneyReference.GetComponent<ScoreManager>().CurrentScore;
		}
	}
		
	void Update () 
	{
		Money = PlayerReference.GetComponent<ShopSelection>().Money;

	}
}
