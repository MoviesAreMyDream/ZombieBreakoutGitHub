using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeapHold : MonoBehaviour
{
    #region Close Portal Settings
    [Header("Close Portal Settings")]
    public int WaitTime = 1;
    private float DownTime;
    private bool isHandled = false;

    public GameObject portal;

//    public Text interactionText;
//    public Image interactionBG;
//    public Image Bbut;

//    public GameObject homeportal;
//    public GameObject progress;
//    public AudioSource homePortalSpawned;

//    public Text goal1;
//    public Text goal2;
//    public Animation GoalTextAnim;

    public GameObject GameManagerGO;
//    public ScoreManager ScrManager;

    public bool played = false;

    private Collider portalcol;
    #endregion

    #region Button Settings
    [Header("Button Settings")]
    public FingerButton PortalClose;
    #endregion

    [Header("Visibility Variables")]
    public bool Visible = true;

    void OnEnable()
    {
        PortalClose.ButtonActivated += Trigger_ButtonActivated;
    }

    void OnDisable()
    {
        PortalClose.ButtonActivated -= Trigger_ButtonActivated;
    }

    void Start ()
    {
        //goal1.enabled = true;
        //goal2.enabled = false;
        //interactionText.enabled = false;
        //interactionBG.enabled = false;
        //Bbut.enabled = false;
        //homeportal.SetActive(false);

        GameManagerGO = GameObject.Find("GameManager");
        //ScrManager = GameManagerGO.GetComponent<ScoreManager>();

        gameObject.GetComponent<CircularProgressBar>().enabled = false;
        //homePortalSpawned.GetComponent<AudioSource>();
    }

    void Trigger_ButtonActivated(FingerButton sender)
    {

            //interactionText.enabled = true;
            //interactionBG.enabled = true;
            //Bbut.enabled = true;
            //gameObject.GetComponent<CircularProgressBar>().enabled = true;

            //ScrManager.GetDynamite();
            //goal1.enabled = false;
            //goal2.enabled = true;
            //interactionText.enabled = false;
            //interactionBG.enabled = false;
            //Bbut.enabled = false;
            portal.SetActive(false);

        if (gameObject.GetComponent<CircularProgressBar>() != null)
        {
            gameObject.GetComponent<CircularProgressBar>().enabled = false;
            //progress.SetActive(false);
        }
    }

    void Update ()
    {
        if (Time.timeSinceLevelLoad / 60 >= 7.001)
            checkAllPortals();
    }

    void checkAllPortals()
    {
        if (!portal.activeSelf)
        {
            //homeportal.SetActive(true);
            if (!played)
            {
                //homePortalSpawned.Play();
                played = true;
            }
        }
    }

    public void Show()
    {
        Visible = true;
        SetButtonVisibility(Visible);
    }

    public void Hide()
    {
        Visible = false;
        SetButtonVisibility(Visible);
    }

    public void SetButtonVisibility(bool visible)
    {
        PortalClose.gameObject.SetActive(Visible);
    }
}
