using UnityEngine;
using System.Collections;

public class LevelLoadingProgressBar : MonoBehaviour {

	public Texture2D emptyProgressBar; // Set this in inspector.
	public Texture2D fullProgressBar; // Set this in inspector.
	
	private AsyncOperation async = null; // When assigned, load is in progress.
	private IEnumerator LoadALevel(string levelName)
	{
		async = Application.LoadLevelAsync(levelName);
		yield return async;
	}

	void OnGUI() 
	{
		if (async != null) 
		{
			GUI.DrawTexture(new Rect(0, 0, 100, 50), emptyProgressBar);//delete this ting soon to be a plane or something
			GUI.DrawTexture(new Rect(0, 0, 100 * async.progress, 50), fullProgressBar);
		}
	}
}
