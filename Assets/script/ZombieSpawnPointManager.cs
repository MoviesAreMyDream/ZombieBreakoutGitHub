using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ZombieSpawnPointManager : MonoBehaviour {
    
    public float zombieSpawnTimer = 0;

    public int zombiesATotal = 20;
    public Transform[] zombieASpawnPoints;
	public GameObject zombieAEnemy;

    public int zombiesBTotal = 6;
    public Transform[] zombieBSpawnPoints;
    public GameObject zombieBEnemy;

    public  int zombiesCTotal = 4;
    public Transform[] zombieCSpawnPoints;
    public GameObject zombieCEnemy;
    /*
    public float ZombieARespawnAt = 1;
    public float ZombieBRespawnAt = 2;
    public float ZombieCRespawnAt = 3;
    */
    int zombiesACurrent;
    int zombiesBCurrent;
    int zombiesCCurrent;
    public int AllZombieCount;

    public int RandomZombieSpawn;

    // Update is called once per frame
    void Update () {

        AllZombieCount = GameObject.FindGameObjectsWithTag("Zombie").Length;

    }

    public int ZombSpawnRate = 2;


    void Start ()
    {
        InvokeRepeating("SpawnRandomZombie", ZombSpawnRate, ZombSpawnRate);
    }
/*
    void ZombieRandomizer ()
    {
        
    }
    */
    void SpawnRandomZombie ()
    {
        RandomZombieSpawn = Random.Range(1, 5);

        if ((RandomZombieSpawn != 4) || (RandomZombieSpawn != 5))
            SpawnZombieA();
        if (RandomZombieSpawn == 4)
            SpawnZombieB();
        if (RandomZombieSpawn == 5)
            SpawnZombieC();
    }

    void SpawnZombieA()
	{
		Vector3 randomSpawnPoint = zombieASpawnPoints [Random.Range (0, zombieASpawnPoints.Length)].position;
        if (zombiesACurrent <= zombiesATotal)
            Instantiate (zombieAEnemy, randomSpawnPoint, Quaternion.identity);
        zombiesACurrent++;
		}

    void SpawnZombieB()
    {
        Vector3 randomSpawnPoint = zombieBSpawnPoints[Random.Range(0, zombieBSpawnPoints.Length)].position;
        Instantiate(zombieBEnemy, randomSpawnPoint, Quaternion.identity);
        zombiesBCurrent++;
    }

    void SpawnZombieC()
    {
        Vector3 randomSpawnPoint = zombieCSpawnPoints[Random.Range(0, zombieCSpawnPoints.Length)].position;
        Instantiate(zombieCEnemy, randomSpawnPoint, Quaternion.identity);
        zombiesCCurrent++;
    }


}
