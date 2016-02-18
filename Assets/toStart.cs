using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class toStart : MonoBehaviour {
    
	public string LevelName;
	public GameObject MainMenuReference;
	public GameObject SoundSourceReference;
	public GameObject LoadingScreenReference;
	//public GameObject ProgressBarReference;
	public GameObject ControlReference;

	private AudioSource audio;

	public GameObject TextReference;

	private AsyncOperation async = null; // When assigned, load is in progress.

	void Start()
	{

	}


	void Update() 
	{
		if ((Input.GetButtonDown ("Fire1")) || (Input.GetButtonDown ("Submit"))) 
		{
			SoundSourceReference.GetComponent<AudioSource>().enabled =  true;
			StartCoroutine(LoadALevel(LevelName)); 
			MainMenuReference.SetActive (false);
			LoadingScreenReference.SetActive (true);
			ControlReference.SetActive (true);
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

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
	

	}

	private IEnumerator LoadALevel(string levelName) {
		async = Application.LoadLevelAsync(levelName);
		async.allowSceneActivation = false;
		yield return async;
	}
	
}
