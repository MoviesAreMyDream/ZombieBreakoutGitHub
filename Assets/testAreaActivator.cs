using UnityEngine;
using System.Collections;

public class testAreaActivator : MonoBehaviour {

    public bool canTouch;

	// Use this for initialization
	void Start () {
        canTouch = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("t"))
        {
            if (canTouch == true)
            {
                print("closing portal...");
            }

            else if (canTouch == false)
            {
                print("no portal nearby");
            }
            
        }
        else
        {
            //print("no portal nearby");
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "TriggerArea")
        {
            canTouch = true;
            Debug.Log("entered");
        }
        else
        {
            canTouch = false;
        }
    }

    void OnTriggerExit (Collider other)
    {
        canTouch = false;
    }
}
