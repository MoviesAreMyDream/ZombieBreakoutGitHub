using UnityEngine;
using System.Collections;

public class toRestart : MonoBehaviour {

	void Update() {
        StartCoroutine(WaitForAWhile());	
	}

    IEnumerator WaitForAWhile ()
    {
        yield return new WaitForSeconds(1);
        if ((Input.anyKey) || Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
            Application.LoadLevel(0);
    }
}
