using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {


    public GameObject AllControl;
    public GameObject Fire;
    public GameObject ChangeWeaponRight;
    public GameObject ChangeWeaponLeft;
    public GameObject Sprint;
    public GameObject Use;
    public GameObject ClosePortal;
    public GameObject Look;
    public GameObject Pause;
    public GameObject Move;

    public bool complete;
        
    void Start () {
        AllControl.SetActive(true);
        Fire.SetActive(false);
        ChangeWeaponRight.SetActive(false);
        ChangeWeaponLeft.SetActive(false);
        Sprint.SetActive(false);
        Use.SetActive(false);
        ClosePortal.SetActive(false);
        Look.SetActive(false);
        Pause.SetActive(false);
        Move.SetActive(false);

        complete = false;
	}
	

	void Update () {
	   // if(Input.GetKeyDown)
	}
}
