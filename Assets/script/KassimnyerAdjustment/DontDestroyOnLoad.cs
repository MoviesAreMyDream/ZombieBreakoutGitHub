using UnityEngine;
using System.Collections;

public class DontDestroyOnLoad : MonoBehaviour {

	
	void Update () {
        DontDestroyOnLoad(transform.gameObject);
    }
}
