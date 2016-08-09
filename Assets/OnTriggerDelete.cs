using UnityEngine;
using System.Collections;

public class OnTriggerDelete : MonoBehaviour {

   public GameObject box;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player" )
        {
            Destroy(box);
            
        }
    }
}
