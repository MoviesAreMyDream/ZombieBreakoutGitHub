using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class intruderDUKE : MonoBehaviour {

	public float distanceBetweenPlayer;
	public float distanceBetweenConsole;

	public bool round1;
	public bool round2;
	public bool round3;

	Transform target;
	NavMeshAgent nav;
	Transform player;
	public float health = 100f;
	CapsuleCollider capsuleCollider;
	SphereCollider sphereCollider;
	Animator anim;
	RaycastHit hit;
	//public GameObject[] pickups;

	private GameObject GameManagerGO;
	private ScoreManager ScrManager;

	private GameObject PlayerReference;
	private PlayerHealthNewChar PlayerScriptReferece;

	Transform navpoint;
	public GameObject Rifle;
	public GameObject hpUI;
	public GameObject flashbang;

	// Use this for initialization
	void Awake () {
		nav = GetComponent <NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		capsuleCollider = GetComponent <CapsuleCollider> ();
		sphereCollider = GetComponent<SphereCollider>();
		anim = GetComponent <Animator> ();
		navpoint = GameObject.FindGameObjectWithTag("START").transform;
		flashbang.GetComponent<Image> ().enabled = false;

	}

	void Start () {

		PlayerReference = GameObject.Find ("OVRPlayerController");
		PlayerScriptReferece = PlayerReference.GetComponent<PlayerHealthNewChar>();


//		GameManagerGO = GameObject.Find("GameManager");
//		ScrManager = GameManagerGO.GetComponent<ScoreManager>();

	}

	float currentValue;
	public bool canAttack = false;

	// Update is called once per frame
	void Update () {

		hpUI.GetComponent<Text>().text = health.ToString ();

		distanceBetweenPlayer = Vector3.Distance(transform.position,player.position);
		distanceBetweenConsole = Vector3.Distance(transform.position,navpoint.position);

		//RotateTowards(navpoint.transform);
		nav.SetDestination(navpoint.position);
//		print(nav.remainingDistance);
		canAttack = false;

		if(distanceBetweenPlayer <= 20)
		{
			canAttack = true;

			if (canAttack == true) {
				nav.stoppingDistance = 15;
				nav.SetDestination (player.position);
				anim.SetBool ("PlayerInRange", true);
				anim.SetBool ("Hack", false);
				RotateTowards(player.transform);


				if (distanceBetweenPlayer <= 15) {
					anim.SetBool ("CanAttack", true);
				}

				else
				{
					anim.SetBool ("CanAttack", false);

				}
			}
		}

		if(distanceBetweenPlayer >= 20)
		{
			canAttack = false;

			if(canAttack == false)
			{
				nav.SetDestination(navpoint.position);
				nav.stoppingDistance = 1;
				anim.SetBool("PlayerInRange",false);
			}

			if(distanceBetweenConsole <= 1)
			{
				anim.SetBool ("Hack", true);
				anim.SetBool ("PlayerInRange", false);
			}
		}

		if (round1 == true) 
		{	
			if (health <= 60) 
			{
				anim.SetBool ("Escape", true);
				capsuleCollider.enabled = false;
				nav.Stop ();
				Rifle.GetComponent<LaserGunBeam_intruder> ().enabled = false;
				capsuleCollider.enabled = false;
				flashbang.GetComponent<Image> ().enabled = true;
				StartCoroutine (Flash ());
				StartCoroutine (Teleport ());
			}

		}

		if(round2 == true)
		{
			if (health <= 30) 
			{
				anim.SetBool ("Escape", true);
				capsuleCollider.enabled = false;
				StartCoroutine (Flash ());
				StartCoroutine (Teleport ());
			}
		}

		if(round3 == true)
		{
			anim.SetBool ("Escape", true);
			capsuleCollider.enabled = false;
			StartCoroutine (Flash ());
			StartCoroutine (Teleport ());
		}

		if(health <= 1)
		{
			Death ();
		}
	
	}

	public void ApplyDamage(float damage)
	{
		health -= damage;

	}
		
	IEnumerator Teleport()
	{
		yield return new WaitForSeconds (1.5f);
		gameObject.SetActive (false);

	}

	IEnumerator Flash()
	{
		yield return new WaitForSeconds (1.5f);
		flashbang.GetComponent<Image> ().CrossFadeAlpha (0f, 2.0f, false);
	}

	void Death()
	{
		
		health = 0;
		anim.SetBool ("StillAlive", false);
		Rifle.GetComponent<LaserGunBeam_intruder> ().enabled = false;
		nav.Stop();
		capsuleCollider.enabled = false;
	
	}



	private void RotateTowards (Transform target) 
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
	}
}
