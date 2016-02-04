using UnityEngine;
using System.Collections;

public class ZombieAIWandering : MonoBehaviour {

	public float wanderRadius;
	public float wanderTime;
	
	private Transform target;
	private NavMeshAgent agent;
	private float Timer;
	public Animator ZombiePref;

	public GameObject Sun;

	// Use this for initialization
	void Start () {
	
		agent = GetComponent<NavMeshAgent>();
		Timer = wanderTime;
		ZombiePref = GetComponent<Animator>();
		gameObject.GetComponent<EnemyZombie>().enabled = false;
		Sun = GameObject.Find ("Sun");
	}
	
	// Update is called once per frame
	void Update () {

		Timer += Time.deltaTime;


		if (Timer >= wanderTime) {
			Vector3 newPos = RandomNavSphere (transform.position, wanderRadius, -1);
			agent.SetDestination (newPos);

			if (agent.SetDestination (newPos)) {
				ZombiePref.SetBool ("PlayerIsDead", true);
				ZombiePref.SetBool ("PlayerInRange", true);
			}

			print("Zombie Stopped");

			StartCoroutine(SetTimerZero(3f));


		} else {

			ZombiePref.SetBool ("PlayerIsDead", false);
			ZombiePref.SetBool ("PlayerInRange", false);
		}

		if(Sun.GetComponent<DayNightCycle>().CurrentTime == "0.00")
		{
			print ("OI");
			gameObject.GetComponent<EnemyZombie>().enabled = true;
			gameObject.GetComponent<ZombieAIWandering>().enabled = false;
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

		Timer = 0;

	}

}
