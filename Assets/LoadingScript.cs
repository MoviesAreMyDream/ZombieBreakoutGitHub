using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{

    AsyncOperation ao;
    public GameObject loadingScreenBG;
    public Slider progBar;

    public bool isFakeLoadingBar = false;
    public float fakeIncrement = 0f;
    public float fakeTiming = 0f;
    public string levelName;

    // Use this for initialization
    void Start()
    {
        loadingScreenBG.SetActive(true);
        progBar.gameObject.SetActive(true);

        if (!isFakeLoadingBar)
        {
            StartCoroutine(LoadLevelWithRealProgress());
        }
        else
        {
            StartCoroutine(loadLevelWithFakeProgress());
        }
    }

    IEnumerator LoadLevelWithRealProgress()
    {
        yield return new WaitForSeconds(1);

        ao = SceneManager.LoadSceneAsync(levelName);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            progBar.value = ao.progress;

            if (ao.progress == 0.9f)
            {
                //progBar.value = 1f;
                yield return new WaitForSeconds(15);
                ao.allowSceneActivation = true;
            }
            
            //Debug.Log(ao.progress);
            yield return null;
        }

    }

    IEnumerator loadLevelWithFakeProgress()
    {
        yield return new WaitForSeconds(1);

        while (progBar.value != 1f)
        {
            progBar.value += fakeIncrement;
            yield return new WaitForSeconds(fakeTiming);
        }

        while (progBar.value == 1f)
        {
            SceneManager.LoadScene(1);
        }

        yield return null;
    }
}
