using UnityEngine;
using System.Collections;

public class CooldownTimer : MonoBehaviour {

	private float Counter;
	public float MaxTimer = 2f;
	public GameObject LaserCount;
	public vp_FPPlayerEventHandler player;
	public GameObject PlayerReference;


	// Use this for initialization
	void Start () {
	
		gameObject.GetComponent<CooldownTimer>().enabled = false;
		PlayerReference = GameObject.Find ("PlayerOVR");
		player = PlayerReference.GetComponent<vp_FPPlayerEventHandler>();
	}
	
	// Update is called once per frame
	void Update () {
	
		print (Counter);

			if (Counter >= MaxTimer) 
			{
//				LaserCount.GetComponent<BulletCount>().player.CurrentWeaponAmmoCount.Set(2);
				Counter = 0;
//				gameObject.GetComponent<CooldownTimer>().enabled = false;
			} 
			else 
			{
				Counter += 1 * Time.fixedDeltaTime;
			}
	}
}
