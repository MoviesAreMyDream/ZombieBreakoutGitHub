using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ZombieSpawnPointManagerOld : MonoBehaviour {

	public int round = 1;
	int zombiesInRound = 20;
	int zombiesSpawnedInRound = 0;
	public float zombiesSpawnTimer = 0;
	public Transform[] zombieSpawnPoints;
	public GameObject zombieEnemy;

    int zombiesBInRound = 6;
    int zombiesBSpawnInRound = 0;
    public float zombiesBSpawnTimer = 0;
    public Transform[] zombieBSpawnPoints;
    public GameObject zombieBEnemy;

    int zombiesCInRound = 4;
    int zombiesCSpawnInRound = 0;
    public float zombiesCSpawnTimer = 0;
    public Transform[] zombieCSpawnPoints;
    public GameObject zombieCEnemy;

    public float ZombieARespawnAt = 1;
    public float ZombieBRespawnAt = 2;
    public float ZombieCRespawnAt = 3;

	//static int playerScore = 0;
	//static int playerCash = 0;

	//public Text score;

	//public GUISkin mySkin;

	// Use this for initialization
	//void Start () {
	//	score.text = "Zombie Kill: " + score.ToString ();
	//}
	
	// Update is called once per frame
	void Update () {
		if(zombiesSpawnedInRound < zombiesInRound)          // Zombies A Spawns
		{
			if(zombiesSpawnTimer > ZombieARespawnAt)
			{
				SpawnZombie ();
				zombiesSpawnTimer = 0;
			}
			else
			{
				zombiesSpawnTimer+=Time.deltaTime;
			}            
		}

        if (zombiesBSpawnInRound < zombiesBInRound)          // Zombies B Spawns
        {
            if (zombiesBSpawnTimer > ZombieBRespawnAt)
            {
                SpawnZombieB();
                zombiesBSpawnTimer = 0;
            }
            else
            {
                zombiesBSpawnTimer += Time.deltaTime;
            }            
        }

        if (zombiesCSpawnInRound < zombiesCInRound)          // Zombies C Spawns
        {
            if(zombiesCSpawnTimer > ZombieCRespawnAt)
            {
                SpawnZombieC();
                zombiesCSpawnTimer = 0;
            }
            else
            {
                zombiesCSpawnTimer += Time.deltaTime;
            }
        }
	}


	void SpawnZombie()
	{
		Vector3 randomSpawnPoint = zombieSpawnPoints [Random.Range (0, zombieSpawnPoints.Length)].position;
		Instantiate (zombieEnemy, randomSpawnPoint, Quaternion.identity);
		zombiesSpawnedInRound ++;
		}

    void SpawnZombieB()
    {
        Vector3 randomSpawnPoint = zombieBSpawnPoints[Random.Range(0, zombieBSpawnPoints.Length)].position;
        Instantiate(zombieBEnemy, randomSpawnPoint, Quaternion.identity);
        zombiesBSpawnInRound++;
    }

    void SpawnZombieC()
    {
        Vector3 randomSpawnPoint = zombieCSpawnPoints[Random.Range(0, zombieCSpawnPoints.Length)].position;
        Instantiate(zombieCEnemy, randomSpawnPoint, Quaternion.identity);
        zombiesCSpawnInRound++;
    }


}
