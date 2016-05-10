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
		ReverseBar.GetComponent<Image>().fillAmount = 1;
	}

	// Update is called once per frame
	void Update () {
	
		Clock clock = Timekeeper.instance.Clock("Zombie");

		if(Input.GetKey(KeyCode.O) || Input.GetAxis("LTrigger")>0.1)
		{
			clock.localTimeScale = -1;
			print("REVERSE");
			ReverseBar.GetComponent<Image>().fillAmount -= 1.0f/time*Time.deltaTime;
			ReverseSound.Play();
		}

		else
		{
			clock.localTimeScale = 1;
			print("FORWARD");
			ReverseBar.GetComponent<Image>().fillAmount += 1.0f/time*Time.deltaTime;
		}
	}
		
}
