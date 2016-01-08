using UnityEngine;
using System.Collections;

public class toStart : MonoBehaviour {
    
	public GameObject MainMenuReference;
	public GameObject LoadingScreenReference;
	//public GameObject ProgressBarReference;
	public GameObject ControlReference;

	private AudioSource audio;


	private AsyncOperation async = null; // When assigned, load is in progress.

	void Start()
	{
		audio = GetComponent<AudioSource>();
	}


	void Update() {

		AudioSource audio = GetComponent<AudioSource>();

		if ((Input.GetButtonDown ("Fire1")) || (Input.GetButtonDown ("Submit"))) 
		{
			MainMenuReference.SetActive (false);
			LoadingScreenReference.SetActive (true);
			ControlReference.SetActive (true);
			audio.enabled = true;

					
		if(audio.isPlaying == false && audio.enabled == true)
		{
			StartCoroutine(LoadALevel(1));
			audio.enabled = false;
		}
		
		
		}

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
	

	}

	private IEnumerator LoadALevel(int levelName) {
		async = Application.LoadLevelAsync(levelName);
//		ProgressBarReference.GetComponent<TextMesh>().text = async.progress.ToString();
		yield return async;
	}
	
}
