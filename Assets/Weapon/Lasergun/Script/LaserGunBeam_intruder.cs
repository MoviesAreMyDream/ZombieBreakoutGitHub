using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LaserGunBeam_intruder : MonoBehaviour {

	public Transform m_muzzle;
	public GameObject m_shotPrefab;
	public AudioSource piupiu;
	public AudioSource reload;
	public int bullet;
	public int tryValue;
	public string outOfBulletString = "|";

	public GameObject intruder;

	private float attacktime;
	public float attackRepeatTime = 1f;

	// Use this for initialization
	void Start () {

		bullet = 20;

	}
	
	// Update is called once per frame
	void Update () {


		Attack();

	}

	void Attack()
	{
		if(Time.time > attacktime)
		{
			if(bullet > 0)
			{
				if (intruder.GetComponent<intruderDUKE>().distanceBetweenPlayer <= 20) //fire
				{
					GameObject go = GameObject.Instantiate(m_shotPrefab, m_muzzle.position, m_muzzle.rotation) as GameObject; //instantiate bullet
					GameObject.Destroy(go, 3f); //bullet is firing

					piupiu.GetComponent<AudioSource>().Play();

					bullet--;
					attacktime = Time.time + attackRepeatTime;
				}
			}
			else
			{

				StartCoroutine(reloadBullet());
			}

			if(bullet == 0)
			{
				intruder.GetComponent<Animator>().SetBool("NoBullet",true);

			}
				
		}
	}

	private IEnumerator reloadBullet() //reloading bullet for 3 seconds
	{

		for (int i = 0; i < 4; i++) //looping for 3 seconds
		{
			yield return new WaitForSeconds(0.5f);

		}

		bullet = 20;
		reload.GetComponent<AudioSource>().Play();
		intruder.GetComponent<Animator>().SetBool("NoBullet",false);

	}
}
