using UnityEngine;
using System.Collections;

public class intruderDUKE : MonoBehaviour {

	public float distanceBetweenPlayer;
	public float distanceBetweenConsole;

	Transform target;
	NavMeshAgent nav;
	Transform player;
	public float health = 100;
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

	// Use this for initialization
	void Awake () {
		nav = GetComponent <NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		capsuleCollider = GetComponent <CapsuleCollider> ();
		sphereCollider = gameObject.GetComponentInChildren<SphereCollider>();
		anim = GetComponent <Animator> ();
		navpoint = GameObject.FindGameObjectWithTag("START").transform;
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
                    nav.SetDestination(player.position);
                    anim.SetBool("PlayerInRange", true);
                    anim.SetBool("Hack", false);

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
                anim.SetBool("PlayerInRange", false);
            }

			if(distanceBetweenConsole <= 1)
			{
				anim.SetBool ("Hack", true);
				anim.SetBool ("PlayerInRange", false);
			}
		}

		if(health <= 60)
		{
			anim.SetBool ("Escape", true);
			capsuleCollider.enabled = false;
			sphereCollider.enabled = false;
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

	void OnTriggerStay(Collider intruder)
	{
		if(intruder.gameObject.tag == "Player")
		{
			nav.SetDestination(player.position);
			RotateTowards(player.transform);
		}			
	}

	void OnTriggerExit(Collider intruder)
	{
		if(intruder.gameObject.tag == "Player")
		{
			nav.SetDestination(navpoint.position);
			RotateTowards(navpoint.transform);
		}
	}


	IEnumerator Teleport()
	{
		yield return new WaitForSeconds (1.5f);
		gameObject.SetActive (false);
	}

	void Death()
	{
		
		health = 0;
		anim.SetBool ("StillAlive", false);
		Rifle.GetComponent<LaserGunBeam_intruder> ().enabled = false;
		nav.Stop();
		capsuleCollider.enabled = false;
		sphereCollider.enabled = false;
	
	}



	private void RotateTowards (Transform target) 
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
	}
}
