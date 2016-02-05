using UnityEngine;
using System.Collections;

public class ZombieAIWandering : MonoBehaviour {

	public float wanderRadius;
	public float wanderTime;
	
	private Transform target;
	private NavMeshAgent agent;
	public float Timer;
	public Animator ZombiePref;

	public GameObject Sun;

	private bool counter = false;

	private Vector3 newPos;
	 

	// Use this for initialization
	void Start () {
	
		agent = GetComponent<NavMeshAgent>();
		Timer = wanderTime	;
		ZombiePref = GetComponent<Animator>();
//		gameObject.GetComponent<EnemyZombie>().enabled = false;
		Sun = GameObject.Find ("Sun");
		ZombiePref.GetComponent<EnemyZombie>().canAttack = false;
	}
	
	// Update is called once per frame
	void Update () {

		Timer += Time.fixedDeltaTime;

//		print (Timer);

		if (Timer >= wanderTime) {



			if (agent.SetDestination (newPos)  && counter == false) {
				print ("Zombie changed direction!");
				counter = true;
				newPos = RandomNavSphere (transform.position, wanderRadius, -1);
				ZombiePref.SetBool ("PlayerIsDead", true);
				ZombiePref.SetBool ("PlayerInRange", true);

			}

			StartCoroutine(SetTimerZero(2f));


		} else {

			ZombiePref.SetBool ("PlayerIsDead", false);
			ZombiePref.SetBool ("PlayerInRange", false);

		}

		if(Sun.GetComponent<DayNightCycle>().CurrentTime == "0.00")
		{
			print ("OI");
			gameObject.GetComponent<EnemyZombie>().enabled = true;
			gameObject.GetComponent<ZombieAIWandering>().enabled = false;
			ZombiePref.GetComponent<EnemyZombie>().canAttack = true;
		}
	}


	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
	{
		Vector3 randDirection = Random.insideUnitSphere*dist;
		randDirection += origin;
		NavMeshHit navHit;
		NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
		return navHit.position;
	}
		
	IEnumerator SetTimerZero(float IdleDelay)
	{
		yield return new WaitForSeconds (IdleDelay);

		RotateTowards(newPos);
		agent.SetDestination (newPos);

		Timer = 0;
		counter = false;

	}

	private void RotateTowards (Vector3 target) 
	{
		Vector3 direction = (target - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
	}
}
