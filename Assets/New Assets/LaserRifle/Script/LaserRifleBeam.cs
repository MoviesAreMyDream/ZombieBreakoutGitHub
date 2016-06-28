using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LaserRifleBeam : MonoBehaviour {


	public Transform m_muzzle;
	public GameObject m_shotPrefab;
	public AudioSource piupiu;
	public AudioSource reload;
	public AudioSource reloading;
	public int bullet;
	public GameObject bulletCounter;
	public Text bulletCounterText;
	public int tryValue;
	public string outOfBulletString;
	public bool reloadingBullet;
	public bool shooting;

	// Use this for initialization
	void Start () {
		bullet = 50;
		bulletCounterText = bulletCounter.GetComponent<Text>();
		reloadingBullet = false;
		shooting = false;
	}

	// Update is called once per frame
	void Update () {

		bullet = int.Parse(bulletCounterText.text);

		if(bullet > 0)
		{
			if (Input.GetMouseButtonDown(0) && !shooting) //fire
			{
				shooting = true;
				StartCoroutine(burstShoot());
			}
		}
		else
			bullet = 0;

		if(bullet == 0)
		{
			if(!reloadingBullet)
			{
				StartCoroutine(reloadBullet());
				Debug.Log("coroutine start");
				reloadingBullet = true;
			}
		}
	}

	private IEnumerator reloadBullet() //reloading bullet for 3 seconds
	{
		bulletCounterText.text = "-";

		for (int i = 0; i < 3; i++) //looping for 3 seconds
		{
			reloading.GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds(2f);
			bulletCounterText.text += "-";
			Debug.Log("reload looping");
		}

		bullet = 50;
		bulletCounterText.text = bullet.ToString();
		reload.GetComponent<AudioSource>().Play();

		Debug.Log("reloaded");
		reloadingBullet = false;
	}

	private IEnumerator burstShoot()
	{
		if(bullet > 0)
		{
			GameObject go = GameObject.Instantiate(m_shotPrefab, m_muzzle.position, m_muzzle.rotation) as GameObject; //instantiate bullet
			GameObject.Destroy(go, 3f); //bullet is firing
			piupiu.GetComponent<AudioSource>().Play();
			bullet--;
			bulletCounterText.text = bullet.ToString();
		}

		yield return new WaitForSeconds(0.1f);

		if(bullet > 0)
		{
			GameObject go2 = GameObject.Instantiate(m_shotPrefab, m_muzzle.position, m_muzzle.rotation) as GameObject; //instantiate bullet
			GameObject.Destroy(go2, 3f); //bullet is firing
			piupiu.GetComponent<AudioSource>().Play();
			bullet--;
			bulletCounterText.text = bullet.ToString();
		}

		yield return new WaitForSeconds(0.1f);

		if(bullet > 0)
		{
			GameObject go3 = GameObject.Instantiate(m_shotPrefab, m_muzzle.position, m_muzzle.rotation) as GameObject; //instantiate bullet
			GameObject.Destroy(go3, 3f); //bullet is firing
			piupiu.GetComponent<AudioSource>().Play();
			bullet--;
			bulletCounterText.text = bullet.ToString();
		}

		yield return new WaitForSeconds(0.1f);
		shooting = false;
	}
}
