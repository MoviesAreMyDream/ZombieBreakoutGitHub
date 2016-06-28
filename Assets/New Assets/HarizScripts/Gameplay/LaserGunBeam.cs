using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LaserGunBeam : MonoBehaviour {

	public Transform m_muzzle;
	public GameObject m_shotPrefab;
	public AudioSource piupiu;
	public int bullet;
	public GameObject bulletCounter;
	public Text bulletCounterText;
	public string outOfBulletString = "|";
	// Use this for initialization
	void Start () {
		bullet = 20;
		bulletCounterText = bulletCounter.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
		bullet = int.Parse(bulletCounterText.text);

		if(bullet > 0)
		{
			if (Input.GetMouseButtonDown(0)) //fire
			{
				GameObject go = GameObject.Instantiate(m_shotPrefab, m_muzzle.position, m_muzzle.rotation) as GameObject; //instantiate bullet
				GameObject.Destroy(go, 3f); //bullet is firing

				piupiu.GetComponent<AudioSource>().Play();

				bullet--;
				bulletCounterText.text = bullet.ToString();

			}
		}
		else
		{
			bulletCounterText.text = "-";
			StartCoroutine(reloadBullet());
		}
	}

	private IEnumerator reloadBullet() //reloading bullet for 3 seconds
	{
		for (int i = 0; i < 4; i++) //looping for 3 seconds
		{
			yield return new WaitForSeconds(1f);
			bulletCounterText.text += "-";
		}

		bullet = 20;
		bulletCounterText.text = bullet.ToString();;
	}
}
