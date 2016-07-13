using UnityEngine;
using System.Collections;

public class NarratorDialogue1 : MonoBehaviour {

	public GameObject Text1;
	public GameObject Text2;
	public GameObject Text3;
	public GameObject Text4;
	public GameObject Text5;
	public GameObject Text6;
	public GameObject Text7;

    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;

    public GameObject door;

	// Use this for initialization
	void Start () {

		Text1.SetActive (true);
		Text2.SetActive (false);
		Text3.SetActive (false);
		Text4.SetActive (false);
		Text5.SetActive (false);
		Text6.SetActive (false);
		Text7.SetActive (false);
        Enemy1.SetActive(false);
        Enemy2.SetActive(false);
        Enemy3.SetActive(false);

        StartCoroutine (DialoguePt1());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator DialoguePt1()
	{
		yield return new WaitForSeconds (3f);
		Text1.SetActive (false);
		Text2.SetActive (true);
		yield return new WaitForSeconds (4f);        
		Text2.SetActive (false);
		Text3.SetActive (true);
		yield return new WaitForSeconds (6f);
        Enemy1.SetActive(true);

        StartCoroutine(test1Complete());
    }

    IEnumerator test1Complete()
    {
        if (Enemy1)
        {
            yield return new WaitForSeconds(3f);
            Debug.Log("enemy vanquished!");
            Enemy1.SetActive(false);
            StartCoroutine(DialoguePt2());
        }
        else
        {
            Debug.Log("restarting...");
            yield return null;
        }
    }

    void test1Incomplete()
    {
        Debug.Log("zombie killing in progress...");
    }

    IEnumerator DialoguePt2()
    {
        Text3.SetActive(false);
        Text4.SetActive(true);
        yield return new WaitForSeconds(6f);
        Text4.SetActive(false);
        Text5.SetActive(true);
        yield return new WaitForSeconds(6f);
        Text5.SetActive(false);
        Text6.SetActive(true);
        yield return new WaitForSeconds(6f);
        Enemy2.SetActive(true);
        Enemy3.SetActive(true);

        StartCoroutine(test2Complete());
    }

    IEnumerator test2Complete()
    {
        if(Enemy2 && Enemy3)
        {
            yield return new WaitForSeconds(8f);
            Enemy2.SetActive(false);
            Enemy3.SetActive(false);
            Text6.SetActive(false);
            Text7.SetActive(true);
            yield return new WaitForSeconds(4f);
            Text7.SetActive(false);
            door.GetComponent<BoxCollider>().enabled = true;
        }

        else
        {
            Debug.Log("still killing zombies...");
        }
    }
}
