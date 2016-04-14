using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletCount : MonoBehaviour {

	public CustomText bullet = null;
	[HideInInspector]
	public vp_FPPlayerEventHandler player = null;
	public float MaxTimer = 2f;
	private float Counter;

	public GameObject PlayerReference;
	public GameObject GameManager;

	public GameObject progress;

	// Use this for initialization
	void Start () {
	
		player = GameObject.FindObjectOfType (typeof(vp_FPPlayerEventHandler)) as vp_FPPlayerEventHandler;
		PlayerReference = GameObject.Find ("PlayerOVR");
		GameManager = GameObject.Find ("GameManager");
		progress.GetComponent<Scrollbar> ().size = 0;
		progress.SetActive (false);
	}

	void Awake()

	{
		progress.SetActive (false);

	}


	// Update is called once per frame
	void Update () {
	
		progress.GetComponent<Scrollbar>().size = Counter / MaxTimer;

		bullet.text = player.CurrentWeaponAmmoCount.Get ().ToString ();


		if (player.CurrentWeaponAmmoCount.Get () == 0 && player.CurrentWeaponName.Get() == "7LaserGun") 
		{
			progress.SetActive (true);

			if (Counter >= MaxTimer) 
			{
				player.CurrentWeaponAmmoCount.Set(20);
				Counter = 0;
				progress.SetActive (false);
			} 
			else 
			{
				Counter += 1 * Time.fixedDeltaTime;
			}

		}



	}

}
