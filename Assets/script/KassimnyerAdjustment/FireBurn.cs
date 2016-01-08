using UnityEngine;
using System.Collections;

public class FireBurn : MonoBehaviour {

	private PlayerHealthNewChar HP;
	public float MainDamage = 2;
	private vp_PlayerEventHandler events = null;
	private GameObject player;


	void Awake()
	{
		//events = player.transform.GetComponent<vp_PlayerEventHandler> ();

	}

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		HP = player.GetComponent<PlayerHealthNewChar>();

		if (other.gameObject.tag == "Player") 
		{

			Debug.Log ("Burn baby burn");

			StartCoroutine(Api ());

		}
	}

	void OnTriggerExit(Collider huehuehue)
	{
		if (huehuehue.gameObject.tag == "Player") {
			StopAllCoroutines();
			print ("Stop burn");

		}
	}

	private IEnumerator Api ()
	{

			for (int i=0; i <= 999; i++) {
				yield return new WaitForSeconds (1);
				HP.remove (MainDamage);

		}

	}
}
