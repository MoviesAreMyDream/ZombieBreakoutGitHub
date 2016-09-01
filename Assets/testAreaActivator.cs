using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class testAreaActivator : MonoBehaviour {
    public string levelName;
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
                SceneManager.LoadSceneAsync(levelName);              
            }

            else if (canTouch == false)
            {
                print("no portal nearby");
            }   
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "TriggerArea")
        {
            canTouch = true;
            Debug.Log("entered");
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.tag == "TriggerArea")
        {
            canTouch = false;
        }
    }
}
