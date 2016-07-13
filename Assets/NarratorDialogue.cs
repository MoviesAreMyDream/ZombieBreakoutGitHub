using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class NarratorDialogue : MonoBehaviour {

	public GameObject Text1;
	public GameObject Text2;
	public GameObject Text3;
	public GameObject Text4;
	public GameObject Text5;
	public GameObject Text6;
	public GameObject Text7;

    public bool test1Passed;
    public bool test2Passed;

    public float imMoved = 0f;

	public GameObject door;

	// Use this for initialization
	void Start () {

        checkImMoved();

        Text1.SetActive (true);
		Text2.SetActive (false);
		Text3.SetActive (false);
		Text4.SetActive (false);
		Text5.SetActive (false);
		Text6.SetActive (false);
		Text7.SetActive (false);

        test1Passed = false;

		StartCoroutine (DialoguePt1());
	}

    void checkImMoved()
    {
        GameObject thePlayer = GameObject.FindGameObjectWithTag("Player");
        FirstPersonController fpsController = thePlayer.GetComponent<FirstPersonController>();
        imMoved = fpsController.m_MoveDir.x;
    }
	
	// Update is called once per frame
	void Update () {

        checkImMoved();
        if (imMoved > 1f)
        {
            test1Passed = true;
        }
        //else test1 = false;

        if (imMoved < 0)
        {
            test2Passed = true;
        }
        //else test2 = false;
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
        Debug.Log("Starting Part 2");

        if (test1Passed == true)
        {
            DialoguePt2();
        }

        else if (test1Passed == false)
        {
            Debug.Log("Not doin anything...");
            Text3.SetActive(false);
            Text3.SetActive(true);
            yield return new WaitForSeconds(5f);
            DialoguePt2();
        }
    }

    void DialoguePt2()
    {
        if (test1Passed == true)
        {
            Debug.Log("Started Yapping Part 2");
            StartCoroutine(StartDialoguePt2());
        }
        else
        {
            /*//Text2.SetActive(false);
            Text3.SetActive(false);
            Text3.SetActive(true);
            StartCoroutine(DialoguePt2());*/
        }
    }

    IEnumerator StartDialoguePt2()
    {
        Text3.SetActive(false);
        Text4.SetActive(true);
        yield return new WaitForSeconds(6f);
        DialoguePt3();
    }

    void DialoguePt3()
    {
        if (test1Passed == true && test2Passed == true)
        {
            Debug.Log("Yadaa Part 3");
            StartCoroutine(StartDialoguePt3());
        }

        else if (test1Passed == true && test2Passed == false)
        {
            Debug.Log("running second check up");
            Text4.SetActive(false);
           StartCoroutine(StartDialoguePt2());
        }
    }

    IEnumerator StartDialoguePt3()
    {
        Text4.SetActive(false);
        Text5.SetActive(true);
        yield return new WaitForSeconds(6f);
        Text5.SetActive(false);
        Text6.SetActive(true);
        yield return new WaitForSeconds(6f);
        Text6.SetActive(false);
        Text7.SetActive(true);
        yield return new WaitForSeconds(4f);
        Text7.SetActive(false);
        door.GetComponent<BoxCollider>().enabled = true;
        Debug.Log("Ended for now");
    }
}
