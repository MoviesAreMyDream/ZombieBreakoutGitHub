using UnityEngine;
using System.Collections;

public class LostControlsScript : MonoBehaviour {

    public enum WaitPeriod
    {
        StillDying,
        NowCanRestart
    }

    public WaitPeriod CurrentPeriod;

    void Awake ()
    {
        CurrentPeriod = WaitPeriod.StillDying;
    }

	void Update () {
        switch (CurrentPeriod)
        {
            case WaitPeriod.StillDying:
                StartCoroutine(WaitForAWhile());
                break;
            case WaitPeriod.NowCanRestart:
                if ((Input.GetButtonDown("Submit")) || (Input.GetButtonDown("Fire1")))
                    Application.LoadLevel(1);
                if (Input.GetButtonDown("Cancel"))
                    Application.LoadLevel(0);
                break;
        }

        
    }

    IEnumerator WaitForAWhile ()
    {
        yield return new WaitForSeconds(2);
        CurrentPeriod = WaitPeriod.NowCanRestart;        
    }
}
