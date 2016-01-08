using UnityEngine;
using System.Collections;

public class LoseManager : MonoBehaviour {

    public Animation CanvasGO;
    public PauseScript GameManagerGO;
    

    void Lose ()
    {
        CanvasGO.Play("CanvasLostAnim");
        GameManagerGO.GetComponent<PauseScript>().enabled = false;
        gameObject.GetComponent<LostControlsScript>().enabled = true; 
    }
    
}
