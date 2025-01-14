﻿using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

    public Texture2D fadeOutTexture; //to overlay screen
    public float fadeSpeed = 0.8f;

    private int drawDepth = -1000; //draw order in hiereachry
    private float alpha = 1.0f;
    private int fadeDir = -1; //dir of fade 1 = fade in

    void OnGUI ()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;

        //force clamp value bewtween 0 and 1
        alpha = Mathf.Clamp01(alpha);

        //set color
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth; //render black texture on top
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade (int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

    void OnLevelWasLoaded ()
    {
        BeginFade(-1);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
