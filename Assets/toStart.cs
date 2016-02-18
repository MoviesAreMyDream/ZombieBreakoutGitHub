using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class toStart : MonoBehaviour {
    
	public string LevelName;
	public GameObject MainMenuReference;
	public GameObject SoundSourceReference;
	public GameObject LoadingScreenReference;
	public GameObject ControlReference;

	[Space(20)]
	public GameObject ProgressBarReference;
	public GameObject LoadingAnimationReference;

	private bool PressedOnce;

	private AsyncOperation async = null; // When assigned, load is in progress.

	void Start()
	{

	}


	void Update() 
	{
		if ((Input.GetButtonDown ("Fire1")) || (Input.GetButtonDown ("Submit")) || (Input.GetKeyDown(KeyCode.Space))) 
		{
			if(PressedOnce == false)
			{
				PressedOnce = true;
				SoundSourceReference.GetComponent<AudioSource>().enabled =  true;
				MainMenuReference.SetActive (false);
				LoadingScreenReference.SetActive (true);
				ControlReference.SetActive (true);
				StartCoroutine(LoadALevel(LevelName)); 
			}
			else
			{
				async.allowSceneActivation = true;
			}
		}
	
		if (async != null) 
		{
			ProgressBarReference.GetComponent<Image>().fillAmount = async.progress + 0.1f;

			if(async.progress >= 0.9f)
			{
				LoadingAnimationReference.GetComponent<Animator>().SetBool("IsDoneLoading",true);
			}
		}


        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
	

	}

	private IEnumerator LoadALevel(string levelName) 
	{
		async = Application.LoadLevelAsync(levelName);
		async.allowSceneActivation = false;
		yield return async;
	}
	
}
