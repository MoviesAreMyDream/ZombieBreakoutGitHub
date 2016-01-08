using UnityEngine;
using System.Collections;

public class SwordTrail : MonoBehaviour {

    public GameObject SwdTrail;

    void Activate ()
    {
        SwdTrail.SetActive(true);
    }

    void Deactivate ()
    {
        SwdTrail.SetActive(false);
    }
}
