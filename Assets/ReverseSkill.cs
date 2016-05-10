using UnityEngine;
using System.Collections;
using Chronos;
using UnityEngine.UI;

public class ReverseSkill : MonoBehaviour {

	public int time;
	private float counter;
	public GameObject ReverseBar;
	public AudioSource ReverseSound;

	void Start()
	{
		ReverseBar.GetComponent<Scrollbar>().size = 1;
	}

	// Update is called once per frame
	void Update () {
	
		Clock clock = Timekeeper.instance.Clock("Zombie");

		if(Input.GetKeyDown(KeyCode.O) || Input.GetAxis("LTrigger")>0.1)
		{
			if(ReverseBar.GetComponent<Scrollbar>().size == 1f)
			{
				clock.localTimeScale = -1;
				print("REVERSE");
				ReverseSound.Play();
			}

		}
			
		if(clock.localTimeScale == -1)
		{
			ReverseBar.GetComponent<Scrollbar>().size -= 1.0f/time*Time.deltaTime;

		}

		if(ReverseBar.GetComponent<Scrollbar>().size <= 0f)
		{
			clock.localTimeScale = 1;

		}

		if(clock.localTimeScale == 1)
		{
			ReverseBar.GetComponent<Scrollbar>().size += 1.0f/time*Time.deltaTime;

		}
	}
		

}
