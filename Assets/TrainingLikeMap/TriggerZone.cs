using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour {

    public GameObject _enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            _enemy.GetComponent<EnemyZombie_TrainingMap>().anim.SetBool("PlayerSeen",true);
        }
    }

}
