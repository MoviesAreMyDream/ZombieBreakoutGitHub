using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour {
    public Camera FPSCam;
    public Camera TPSCam;
    bool fpsMode = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("escape"))
        {
            fpsMode = !fpsMode;
            FPSCam.gameObject.SetActive(fpsMode);
            TPSCam.gameObject.SetActive(!fpsMode);
        }

    }
}
