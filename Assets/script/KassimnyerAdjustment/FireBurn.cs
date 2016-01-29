using UnityEngine;
using System.Collections;

public class FireBurn : MonoBehaviour {

	private PlayerHealthNewChar HP;
	public float MainDamage = 2;
	private vp_PlayerEventHandler events = null;
	private GameObject player;

	private float InitDamage;
	private int Counter = 1;
	void Awake()
	{
		InitDamage = MainDamage;
		//events = player.transform.GetComponent<vp_PlayerEventHandler> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		HP = player.GetComponent<PlayerHealthNewChar>();
	}

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {

		if (HP.currentHealth <= 0f && Counter == 1) 
		{
			Counter = 0;
			StopAllCoroutines();
			HP.currentHealth = 0f;
		}
	
	}

	void OnTriggerEnter (Collider other)
	{

		if (other.gameObject.tag == "Player") 
		{

//			Debug.Log ("Burn baby burn");

			StartCoroutine(Api ());

		}
	}

	void OnTriggerExit(Collider huehuehue)
	{
		if (huehuehue.gameObject.tag == "Player") {
			StopAllCoroutines();
			MainDamage =  InitDamage;
//			print ("Stop burn");

		}
	}

	private IEnumerator Api ()
	{

			for (int i=0; i <= 999; i++) {
				yield return new WaitForSeconds (1);
				HP.remove (MainDamage);
				MainDamage++;
		}

	}
}
