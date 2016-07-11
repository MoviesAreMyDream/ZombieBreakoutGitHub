using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SimpleLoadLevel : MonoBehaviour {

    public string levelName;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine (NextMap());
        }
    }

    IEnumerator NextMap()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(levelName);
    }
}
