using UnityEngine;
using System.Collections;

public class PlayerHealthNewChar : MonoBehaviour {
	
	public float startingHealth = 100f;
	public float currentHealth;
	
	private GameObject HealthAnimGO;
	private Animation HealthAnim;
	
	private GameObject HealthPlusGO;
	private CustomText HealthPlus;
	private Animation HealthPlusAnim;

	public GameObject HP;
	private CustomText customPref;

	private GameObject PlayerReference;
	private vp_FPPlayerDamageHandler PlayerDmgHandler;// the component is disabled when playing
	private PlayerHealthNewChar ComponentReference;//didnt work

	private GameObject[] ZombiesAll;
	public NavMeshAgent[] ZombieNavMesh;

	public bool PlayerIsDead = false;

	private GameObject CharAnimGO;
	private Animation CharAnim;

	protected vp_FPPlayerEventHandler eventplayer = null;
	private vp_PlayerDamageHandler plydmg;

	public GameObject Waktu;


	void Awake() {

		Time.timeScale = 1;
		
		currentHealth = startingHealth;


		HealthAnimGO = GameObject.Find("HealthNum");
		HealthAnim = HealthAnimGO.GetComponent<Animation>();
		
		HealthPlusGO = GameObject.Find("HealthNumPlus");
		HealthPlus = HealthPlusGO.GetComponent<CustomText>();
		HealthPlusAnim = HealthPlusGO.GetComponent<Animation>();
		
		HealthPlus.text = "";

		ZombiesAll = GameObject.FindGameObjectsWithTag("Zombie");
		
		ZombieNavMesh = new NavMeshAgent[ZombiesAll.Length];
		for (int i = 0; i < ZombiesAll.Length; i++)
		{
			ZombieNavMesh[i] = ZombiesAll[i].GetComponent<NavMeshAgent>();
		}

	
	}


	void Start()
	{	
		PlayerReference = GameObject.Find("PlayerOVR");
		PlayerDmgHandler = PlayerReference.GetComponent<vp_FPPlayerDamageHandler>();
		customPref = HP.GetComponent<CustomText>();
	}

	void Update() {
		
		PlayerDmgHandler.CurrentHealth = currentHealth/10;


		if (currentHealth <= 0f) 
		{
			currentHealth = 0;
			PlayerIsDead = true;
			gameObject.GetComponent<AudioListener>().enabled = false;
			Waktu.GetComponent<TimeManager>().enabled = false;
			PlayerDmgHandler.Die();

		}
		

	}

	public void remove(float amount) { //animation when damaged

		currentHealth -= amount;
		HealthAnim.Play("HealthNumAnim");

		StartCoroutine(HealthNumPlusVisibility());
		HealthPlus.text = "- " + amount.ToString() + " points";
		HealthPlusAnim.Play("HealthNumPlusAnim");
	}
	
	public void add(float amount){ //animation when healed
		currentHealth += amount;
		HealthAnim.Play("HealthNumAnim");
		
		StartCoroutine(HealthNumPlusVisibility());
		HealthPlus.text = "+ " + amount.ToString() + " points";
		HealthPlusAnim.Play("HealthNumPlusAnim");
	}


	IEnumerator HealthNumPlusVisibility()
	{
		HealthPlus.enabled = true;
		yield return new WaitForSeconds(0.5f);
		HealthPlus.enabled = false;
	}


	
	
}