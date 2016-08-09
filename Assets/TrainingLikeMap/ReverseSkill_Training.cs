using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Chronos;

public class ReverseSkill_Training : MonoBehaviour {

    public int time;
    private float counter;
    public GameObject ReverseIcon;
    public AudioSource ReverseSound;
    public bool isActivate;
    public Collider steamCol;
    public GameObject steam;

    void OnEnable()
    {
        isActivate = false;
    }

    void OnDisable()
    {
        isActivate = true;
    }

    // Use this for initialization
    void Start () {

        //ReverseIcon.GetComponent<Image>().fillAmount = 1;
	}
	
	// Update is called once per frame
	public void Update () {

        Clock clock = Timekeeper.instance.Clock("Zombie");

        if(isActivate == true)
        {
            ReverseActivate();
        }

        if (isActivate == false)
        {
            ReverseDeactivate();
        }
    }

    public void ReverseActivate()
    {

        Clock clock = Timekeeper.instance.Clock("Zombie");
        print("reverse");

        //clock.localTimeScale = -1;
        ReverseSound.Play();
        steamCol.enabled = false;
        steam.GetComponent<ParticleSystem>().emissionRate = 10f;
        //ReverseIcon.GetComponent<Image>().fillAmount -= 1 / time * Time.deltaTime;
    }
    
    public void ReverseDeactivate()
    {
        Clock clock = Timekeeper.instance.Clock("Zombie");

        //clock.localTimeScale = 1;
        //ReverseIcon.GetComponent<Image>().fillAmount += 1 / time * Time.deltaTime;

    }
}
