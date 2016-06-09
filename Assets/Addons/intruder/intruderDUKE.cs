using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class intruderDUKE : MonoBehaviour {

	public float distanceBetweenPlayer;
	public float distanceBetweenConsole;
    public float distanceBetweenPointA;

	public bool round1;
	public bool round2;
	public bool round3;

	Transform target;
	NavMeshAgent nav;
	Transform player;
	public float health = 100;
	CapsuleCollider capsuleCollider;
	Animator anim;
	RaycastHit hit;

	private GameObject GameManagerGO;
	private ScoreManager ScrManager;

	private GameObject PlayerReference;
	private PlayerHealthNewChar PlayerScriptReferece;

	Transform navpoint;
    Transform dodgePoint;
	public GameObject Rifle;

	// Use this for initialization
	void Awake () {
		nav = GetComponent <NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		capsuleCollider = GetComponent <CapsuleCollider> ();
		anim = GetComponent <Animator> ();
		navpoint = GameObject.FindGameObjectWithTag("START").transform;
        dodgePoint = GameObject.FindGameObjectWithTag("Dodge").transform;
    }

	void Start () {

		PlayerReference = GameObject.Find ("OVRPlayerController");
		PlayerScriptReferece = PlayerReference.GetComponent<PlayerHealthNewChar>();
//		GameManagerGO = GameObject.Find("GameManager");
//		ScrManager = GameManagerGO.GetComponent<ScoreManager>();

	}

	public bool canAttack = false;
    public bool canDodge = false;

	// Update is called once per frame
	void Update () {

		distanceBetweenPlayer = Vector3.Distance(transform.position,player.position);
		distanceBetweenConsole = Vector3.Distance(transform.position,navpoint.position);
        distanceBetweenPointA = Vector3.Distance(transform.position, dodgePoint.position);

        nav.SetDestination(navpoint.position);
		canAttack = false;
        canDodge = false;

		if(distanceBetweenPlayer <= 20)
		{
			canAttack = true;
            canDodge = true;

			if (canAttack == true)
            {
				nav.stoppingDistance = 15;
				nav.SetDestination (player.position);
				RotateTowards (player.transform);
				anim.SetBool ("PlayerInRange", true);
				anim.SetBool ("Hack", false);

				if (distanceBetweenPlayer <= 15)
                {
					anim.SetBool ("CanAttack", true);
				}

				else
				{
					anim.SetBool ("CanAttack", false);

				}             
			}

            if (canDodge == true && distanceBetweenPointA <= 2)
            {
                nav.stoppingDistance = 0;
                nav.SetDestination(dodgePoint.position);
                anim.SetBool("PlayerInRange", false);
                anim.SetBool("CanAttack", true);
                anim.SetBool("Hack", false);
                //canAttack = true;
                //canDodge = false;
                StartCoroutine(backUp());

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


			if (health <= 60) 
			{
                anim.SetBool ("Escape", true);
				Rifle.GetComponent<LaserGunBeam_intruder> ().enabled = false;
				capsuleCollider.enabled = false;
				round1 = false;
				StartCoroutine (Teleport ());
			}
		


			if(health <= 30)
			{
				anim.SetBool ("Escape", true);
				Rifle.GetComponent<LaserGunBeam_intruder> ().enabled = false;
				capsuleCollider.enabled = false;
				round2 = false;
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

    IEnumerator backUp()
    {
        yield return new WaitForSeconds(5f);
        anim.SetBool("CanAttack", false);
        anim.SetBool("PlayerInRange", true);
        nav.stoppingDistance = 0;
        RotateTowards(navpoint.transform);
        nav.SetDestination(navpoint.position);
        canAttack = false;
        canDodge = false;
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
		
	}



	private void RotateTowards (Transform target) 
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
	}
}
