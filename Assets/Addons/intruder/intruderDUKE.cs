using UnityEngine;
using System.Collections;

public class intruderDUKE : MonoBehaviour {

	public float distance;

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

	// Use this for initialization
	void Awake () {
		nav = GetComponent <NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		capsuleCollider = GetComponent <CapsuleCollider> ();
		sphereCollider = GetComponent<SphereCollider>();
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

		distance = Vector3.Distance(transform.position,player.position);
		//RotateTowards(navpoint.transform);
		nav.SetDestination(navpoint.position);
//		print(nav.remainingDistance);
		canAttack = false;

		if(distance <= 20)
		{
			canAttack = true;

			if(canAttack == true)
			{
				nav.stoppingDistance = 12;
				nav.SetDestination(player.position);
				anim.SetBool("PlayerInRange",true);

			}
		}

		if(distance >= 20)
		{
			canAttack = false;

			if(canAttack == false)
			{
				nav.SetDestination(navpoint.position);
				nav.stoppingDistance = 1;
				anim.SetBool("PlayerInRange",false);
			}
		}
			


	}

	void OnTriggerStay(Collider intruder)
	{
		if(intruder.gameObject.tag == "Player")
		{
			nav.SetDestination(player.position);
			RotateTowards(player.transform);

		}

		if(intruder.gameObject.tag == "START")
		{
			anim.SetBool("Detected",true);
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



	private void RotateTowards (Transform target) 
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
	}
}
