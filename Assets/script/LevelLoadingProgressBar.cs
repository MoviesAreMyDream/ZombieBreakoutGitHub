using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoadingProgressBar : MonoBehaviour {

	public string Level;
	public GameObject SoundSourceReference;
	public GameObject TextReference;

	private AsyncOperation async = null; // When assigned, load is in progress.

	void Update()
	{


		if(Input.GetKeyDown(KeyCode.Space))
		{
			SoundSourceReference.GetComponent<AudioSource>().enabled =  true;
			StartCoroutine(LoadALevel(Level));
		}

		if(Input.GetKeyDown(KeyCode.LeftControl))
		{
			async.allowSceneActivation = true;
		}

		if (async != null) 
		{
			transform.GetComponent<Image>().fillAmount = async.progress + 0.1f;
			if(async.progress >= 0.9f)
			{
				transform.GetComponent<Animator>().SetBool("IsDoneLoading",true);
				TextReference.GetComponent<Text>().text = "Now press Ctrl. Thank for wait";
			}
		}

	}

	private IEnumerator LoadALevel(string levelName)
	{
		async = SceneManager.LoadSceneAsync(levelName);
		async.allowSceneActivation = false;
		yield return async;
	}



//	void OnGUI() 
//	{
//		if (async != null) 
//		{
//			GUI.DrawTexture(new Rect(0, 0, 100, 50), emptyProgressBar);//delete this ting soon to be a plane or something
//			GUI.DrawTexture(new Rect(0, 0, 100 * async.progress, 50), fullProgressBar);
//		}
//	}
}
