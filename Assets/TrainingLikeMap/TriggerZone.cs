using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour {

    public GameObject _enemy;
    public GameObject _mutant1;
    public GameObject _mutant2;
    public GameObject _dog1;
    public GameObject _dog2;
    public GameObject player;

    public bool playerSeen;
    public bool canJoin;

    public AudioSource moreEnemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(playerSeen)
        {
             _enemy.GetComponent<EnemyZombie_TrainingMap>().anim.SetBool("PlayerSeen", true);
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        
        {
            if (hit.gameObject.tag == "Player")
            {
                playerSeen = true;

                _enemy.GetComponent<EnemyZombie_TrainingMap>().enabled = true;
                //_enemy.GetComponent<EnemyZombie_TrainingMap>().anim.SetBool("PlayerSeen", playerSeen);
                player.GetComponent<PlayerHealthNewChar>().PlayerIsDead = false;
                StartCoroutine(Chase());
                StartCoroutine(Join());
            }
        }
    }

    IEnumerator Chase()
    {
        yield return new WaitForSeconds(4f);
        _enemy.GetComponent<NavMeshAgent>().enabled = true;
    }

    IEnumerator Join()
    {
        yield return new WaitForSeconds(10f);
        _mutant1.SetActive(true);
        _mutant2.SetActive(true);
        _dog1.SetActive(true);
        _dog2.SetActive(true);
        moreEnemy.Play();
    }
}
