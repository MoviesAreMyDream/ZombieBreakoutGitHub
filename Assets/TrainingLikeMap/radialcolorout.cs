using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class radialcolorout : MonoBehaviour {

    private float time;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.GetComponent<Image>().fillAmount += 0.02f / time * Time.deltaTime;

    }
}
