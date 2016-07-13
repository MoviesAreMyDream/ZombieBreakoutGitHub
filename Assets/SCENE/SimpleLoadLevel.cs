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
        yield return new WaitForSeconds(1.0f);
        /*float fadeTime = GameObject.Find("FadeControl").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);*/
        SceneManager.LoadScene(levelName);
    }
}
