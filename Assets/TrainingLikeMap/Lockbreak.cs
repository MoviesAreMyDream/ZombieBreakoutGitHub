using UnityEngine;
using System.Collections;

public class Lockbreak : MonoBehaviour {

    public GameObject door;

	// Use this for initialization
	void Start () {

        door.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update () {


    }

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            door.GetComponent<Animator>().enabled = true;
        }
    }
}
