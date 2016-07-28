using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class intruderDUKE : MonoBehaviour {

	public float distanceBetweenPlayer;
	public float distanceBetweenConsole;
    public float distanceBetweenDodge;

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
    public GameObject Duke2;
    public GameObject currentConsole;
    public GameObject otherConsole;
    public GameObject voiceMail;

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

		//PlayerReference = GameObject.Find ("OVRPlayerController");
        PlayerReference = GameObject.Find("PlayerOVR");
        PlayerScriptReferece = PlayerReference.GetComponent<PlayerHealthNewChar>();
//		GameManagerGO = GameObject.Find("GameManager");
//		ScrManager = GameManagerGO.GetComponent<ScoreManager>();

	}

	public bool canAttack = false;
    public bool canDodge = false;

	// Update is called once per frame
	void Update () {

		distanceBetweenPlayer = Vector3.Distance(transform.position, player.position);
		distanceBetweenConsole = Vector3.Distance(transform.position, navpoint.position);
        distanceBetweenDodge = Vector3.Distance(transform.position, dodgePoint.position);

        nav.SetDestination(navpoint.position);
		canAttack = false;
        canDodge = false;

		if(distanceBetweenPlayer <= 10)
		{
			canAttack = true;

			if (canAttack == true)
            {
				nav.stoppingDistance = 8;
				nav.SetDestination (player.position);
				RotateTowards (player.transform);
				anim.SetBool ("PlayerInRange", true);
				anim.SetBool ("Hack", false);

				if (distanceBetweenPlayer <= 8)
                {
					anim.SetBool ("CanAttack", true);
				}

				else
				{
					anim.SetBool ("CanAttack", false);

				}             
			}

            if (distanceBetweenDodge <= 2)
            {
                canDodge = true;
                canAttack = false;

                nav.stoppingDistance = 1;
                nav.SetDestination(dodgePoint.position);
                anim.SetBool("PlayerInRange", false);
                anim.SetBool("CanAttack", false);
                anim.SetBool("Hack", true);

                if (canDodge = true && distanceBetweenPlayer <= 10)
                {
                    canAttack = false;
                    canDodge = false;
                    anim.SetBool("PlayerInRange", false);
                    anim.SetBool("CanAttack", false);
                    anim.SetBool("Hack", false);
                }

                StartCoroutine(backUp());
            }
        }

		if(distanceBetweenPlayer >= 11)
		{
			canAttack = false;
            canDodge = false;

			if(canAttack == false)
			{
				nav.SetDestination(navpoint.position);
                nav.stoppingDistance = 1;
                anim.SetBool("PlayerInRange", true);
                anim.SetBool("Hack",false);
			}

			if(distanceBetweenConsole <= 1)
			{
                anim.SetBool("PlayerInRange", false);
                anim.SetBool ("Hack", true);
			}
		}

		if(round1)
		{
			if (health <= 60) 
			{
                anim.SetBool("PlayerInRange", false);
                anim.SetBool("CanAttack", false);
                anim.SetBool("Hack", false);
                anim.SetBool ("Escape", true);
				Rifle.GetComponent<LaserGunBeam_intruder> ().enabled = false;
				capsuleCollider.enabled = false;
				round1 = false;
                Duke2.SetActive(true);
                currentConsole.SetActive(false);
                otherConsole.SetActive(true);
                voiceMail.SetActive(true);
                StartCoroutine (Teleport ());
			}
		}
			
		
		if(round2)
		{
			if(health <= 10)
			{
                anim.SetBool("PlayerInRange", false);
                anim.SetBool("CanAttack", false);
                anim.SetBool("Hack", false);
                anim.SetBool ("Escape", true);
				Rifle.GetComponent<LaserGunBeam_intruder> ().enabled = false;
				capsuleCollider.enabled = false;
				round2 = false;
                otherConsole.SetActive(false);
				StartCoroutine (Teleport ());
			}
		}

		if(round3)
		{
			if(health <= 1)
			{
				Death ();
			}
		}
	
	}

	public void ApplyDamage(float damage)
	{
		health -= damage;

		}	


    IEnumerator backUp()
    {
        //canAttack = false;
        //canDodge = false;
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("PlayerInRange", false);
        anim.SetBool("CanAttack", false);
        anim.SetBool("Hack", false);
        nav.stoppingDistance = 2;
        nav.SetDestination(navpoint.position);

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
