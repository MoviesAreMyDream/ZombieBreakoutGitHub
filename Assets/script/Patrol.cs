using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {

	public Transform[] waypoints;
	public int NextDest = 0;

	private NavMeshAgent agent;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		agent.stoppingDistance = 0;
	}

	void Update()
	{
		if (agent.remainingDistance < 0.5f) 
		{
			agent.SetDestination(waypoints[NextDest].position);
			NextDest = (NextDest + 1) % waypoints.Length;
		}

		if(agent.remainingDistance > 0.5f)
		{
		}
	}


}