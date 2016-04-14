using UnityEngine;
using System.Collections;

public class particleColor : MonoBehaviour {

	public GameObject Sun;
	public GameObject Dust;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () 
	{
		/*if (Sun.GetComponent<DayNightCycle>().TimeFloat >= 13 && Sun.GetComponent<DayNightCycle>().TimeFloat <= 13.5)
		{
			Dust.gameObject.GetComponent<Renderer> ().material.SetColor("_TintColor", new Color (0.2f, 0.2f, 0.2f, 0.35f));
		}*/

		if (Sun.GetComponent<DayNightCycle>().TimeFloat >= 13.75)
		{
			Dust.gameObject.GetComponent<Renderer> ().material.SetColor("_TintColor", new Color (0.37f, 0.38f, 0.43f, 0.17f));
		}

	}
}
