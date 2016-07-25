using UnityEngine;
using System.Collections;

public class enterTriggerVoice : MonoBehaviour {

    public GameObject oldMessage;
    public GameObject newMessage;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            readyToPlayAudio();
            //oldMessage.SetActive(false);
            //newMessage.SetActive(true);
        }
    }

    void readyToPlayAudio()
    {
        StartCoroutine (playAudio());
    }

    IEnumerator playAudio()
    {
        yield return new WaitForSeconds(0f);
        oldMessage.SetActive(false);
        newMessage.SetActive(true);
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //gameObject.SetActive(false);
        }
    }
}
