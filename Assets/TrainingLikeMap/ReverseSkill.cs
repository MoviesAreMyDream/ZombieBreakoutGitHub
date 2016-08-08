using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Chronos;

public class ReverseSkill : MonoBehaviour {

    public int time;
    private float counter;
    public GameObject ReverseIcon;
    public AudioSource ReverseSound;
    public bool isActivate;

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

    void ReverseActivate()
    {

        Clock clock = Timekeeper.instance.Clock("Zombie");
        print("reverse");

        //clock.localTimeScale = -1;
        ReverseSound.Play();
        //ReverseIcon.GetComponent<Image>().fillAmount -= 1 / time * Time.deltaTime;
    }
    
    void ReverseDeactivate()
    {
        Clock clock = Timekeeper.instance.Clock("Zombie");

        //clock.localTimeScale = 1;
        //ReverseIcon.GetComponent<Image>().fillAmount += 1 / time * Time.deltaTime;

    }
}
