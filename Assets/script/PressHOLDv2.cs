using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PressHOLDv2 : MonoBehaviour {

    public int WaitTime = 1;
    private float DownTime;
    private bool isHandled = false;

    public GameObject portal1;
    public GameObject portal2;
    public GameObject portal3;
    public GameObject portal4;
    public GameObject portal5;
    public GameObject portal6;

    public Text interactionText;
    public Image interactionBG;
    public Image Bbut;

    public GameObject homeportal;
    public GameObject progress;
    public AudioSource homePortalSpawned;

    public Text goal1;
    public Text goal2;
    public Animation GoalTextAnim;

	public GameObject narrator;

    public GameObject GameManagerGO;
    public ScoreManager ScrManager;

    public bool played = false;

    // Use this for initialization
    void Start()
    {

        goal1.enabled = true;
        goal2.enabled = false;
        interactionText.enabled = false;
        interactionBG.enabled = false;
        Bbut.enabled = false;
        homeportal.SetActive(false);
		narrator.SetActive(false);

        GameManagerGO = GameObject.Find("GameManager");
        ScrManager = GameManagerGO.GetComponent<ScoreManager>();

        gameObject.GetComponent<CircularProgressBar>().enabled = false;
        homePortalSpawned.GetComponent<AudioSource>();

    }


    // Update is called once per frame
    void OnTriggerStay(Collider portalcol)
    {

        if (portalcol.gameObject.tag == "Portal")
        {

            interactionText.enabled = true;
            interactionBG.enabled = true;
            Bbut.enabled = true;
            gameObject.GetComponent<CircularProgressBar>().enabled = true;

            if (Input.GetButtonDown("Fire3") || Input.GetKeyDown(KeyCode.F))
            { //Key was pressed down, so take up time.
                DownTime = Time.time;
                isHandled = false;


            }
            if (Input.GetButton("Fire3") || Input.GetKey(KeyCode.F))
            { // is key still being hold down...  
              // And is it been hold over the time we want and is not handled yet?
                if ((Time.time > DownTime + WaitTime))
                {
                    // We've been here, don't do this again until button is pressed again.
                    isHandled = true;
                    // Do Something here
                    Debug.Log("Key \"B\" was pressed over " + WaitTime + " seconds.");
                    //					portal.SetActive (false);
                    ScrManager.GetDynamite();
                    goal1.enabled = false;
                    goal2.enabled = true;
                    interactionText.enabled = false;
                    interactionBG.enabled = false;
                    Bbut.enabled = false;
                    //Destroy (gameObject);

                    if (portalcol.gameObject.name == "PortalMap (1)")
                        portal1.SetActive(false);
                    else if (portalcol.gameObject.name == "PortalMap (2)")
                        portal2.SetActive(false);
                    else if (portalcol.gameObject.name == "PortalMap (3)")
                        portal3.SetActive(false);
                    else if (portalcol.gameObject.name == "PortalMap (4)")
                        portal4.SetActive(false);
                    else if (portalcol.gameObject.name == "PortalMap (5)")
                        portal5.SetActive(false);
                    else if (portalcol.gameObject.name == "PortalMap (6)")
                        portal6.SetActive(false);


                  
                }

            }


        }

        else
            if (gameObject.GetComponent<CircularProgressBar>() != null)
        {
            gameObject.GetComponent<CircularProgressBar>().enabled = false;
            progress.SetActive(false);
        }

    }


    void Update()
    {
        if (Time.timeSinceLevelLoad / 60 >= 7.01f)
            checkAllPortals();
    }

    void OnTriggerExit()
    {
        interactionText.enabled = false;
        interactionBG.enabled = false;
        Bbut.enabled = false;

        if (gameObject.GetComponent<CircularProgressBar>() != null)
            gameObject.GetComponent<CircularProgressBar>().enabled = false;
    }

    void checkAllPortals()
    {
        if (!portal1.activeSelf && !portal2.activeSelf && !portal3.activeSelf && !portal4.activeSelf && !portal5.activeSelf && !portal6.activeSelf)
        {
            homeportal.SetActive(true);
            if (!played)
            {
                homePortalSpawned.Play();
                played = true;
				narrator.SetActive(true);
				StartCoroutine(FadeAway());
            }
        }
    }

	IEnumerator FadeAway()
	{
		yield return new WaitForSeconds(6.5f);
		narrator.SetActive(false);
	}
}
