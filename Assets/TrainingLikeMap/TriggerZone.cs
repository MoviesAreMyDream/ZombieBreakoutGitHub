using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour {

    public GameObject _enemy;
    public GameObject _mutant1;
    public GameObject _mutant2;
    public GameObject _dog1;
    public GameObject _dog2;

    public bool zoneStart = false;
    public bool zone1 = false;
    public bool zone2 = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider hit)
    {
        zoneStart = true;

        if (zone1 == true)
        {
            if (hit.gameObject.tag == "Player" && zoneStart == true)
            {
                _enemy.GetComponent<EnemyZombie_TrainingMap>().enabled = true;
                _enemy.GetComponent<EnemyZombie_TrainingMap>().anim.SetBool("PlayerSeen", true);
                _enemy.GetComponent<EnemyZombie_TrainingMap>().PlayerScriptReferece.PlayerIsDead = false;
                StartCoroutine(Chase());
            }
        }

        if(zone2 == true)
        {
            if (hit.gameObject.tag == "Player" && zoneStart == true)
            {
                _mutant1.SetActive(true);
                _mutant2.SetActive(true);
                _dog1.SetActive(true);
                _dog2.SetActive(true);

            }
        }   

    }

    IEnumerator Chase()
    {
        yield return new WaitForSeconds(1f);
        _enemy.GetComponent<>();
    }

}
