using UnityEngine;
using System.Collections;

public class SpawnOtherEnemy : MonoBehaviour {

    public GameObject Enemy;
    public GameObject otherEnemy_1;
    public GameObject otherEnemy_2;
    public GameObject otherEnemy_3;



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Enemy.GetComponent<EnemyZombie_TrainingMap>().health == 0)
        {
            otherEnemy_1.SetActive(true);
            otherEnemy_2.SetActive(true);
            otherEnemy_3.SetActive(true);

        }

    }
}
