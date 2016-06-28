using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeapShoot : MonoBehaviour
{
    #region Weapon Settings
    [Header("Weapon Settings")]
    public Transform m_muzzle;
    public GameObject m_shotPrefab;
    public AudioSource piupiu;
    public int bullet;
    public GameObject bulletCounter;
    public Text bulletCounterText;
    public string outOfBulletString = "|";
    #endregion

    #region Button Settings
    [Header("Button Settings")]
    public FingerButton Trigger;
    #endregion

    /*
    #region Hand Variables
    [Header("Hand Variables")]
    public Transform Forearm;
    public Vector3 LocalOffset;
    #endregion
    */

    [Header("Visibility Variables")]
    public bool Visible = true;

    void OnEnable()
    {
        Trigger.ButtonActivated += Trigger_ButtonActivated;
    }

    void OnDisable()
    {
        Trigger.ButtonActivated -= Trigger_ButtonActivated;
    }

    void Start()
    {
        //transform.SetParent(Forearm);
        //transform.localPosition = LocalOffset;
        bullet = 20;
        bulletCounterText = bulletCounter.GetComponent<Text>();
    }

    void Trigger_ButtonActivated(FingerButton sender)
    {
        if (bullet > 0)
        {
                GameObject go = GameObject.Instantiate(m_shotPrefab, m_muzzle.position, m_muzzle.rotation) as GameObject; //instantiate bullet
                GameObject.Destroy(go, 3f); //bullet is firing

                piupiu.GetComponent<AudioSource>().Play();

                bullet--;
                bulletCounterText.text = bullet.ToString();
        }
        else
        {
            bulletCounterText.text = "-";
            StartCoroutine(reloadBullet());
        }
    }

    void Update()
    {
        bullet = int.Parse(bulletCounterText.text);
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
        Trigger.gameObject.SetActive(Visible);
    }

    private IEnumerator reloadBullet() //reloading bullet for 3 seconds
    {
        for (int i = 0; i < 4; i++) //looping for 3 seconds
        {
            yield return new WaitForSeconds(1f);
            bulletCounterText.text += "-";
        }

        bullet = 20;
        bulletCounterText.text = bullet.ToString(); ;
    }
}
