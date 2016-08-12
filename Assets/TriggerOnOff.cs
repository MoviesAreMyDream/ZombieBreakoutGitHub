using UnityEngine;
using System.Collections;

public class TriggerOnOff : MonoBehaviour
{
    public GameObject desiredObject1;
    public GameObject desiredObject2;
    //public GameObject oldMessage;
    //public GameObject newMessage;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            desiredObject1.SetActive(false);
            desiredObject2.SetActive(true);
            //oldMessage.SetActive(false);
            //newMessage.SetActive(true);
        }
    }

    /*void readyToPlayAudio()
    {
        StartCoroutine(playAudio());
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
    }*/
}
