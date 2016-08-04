/* The MIT License (MIT)

Copyright (c) 2016 Joshua Corvinus

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE. */

using UnityEngine;
using System.Collections;

public class LeapMenu : MonoBehaviour
{
    #region Button Variables
    [Header("Button Variables")]
    public FingerButton NextLevelButton;
    public FingerButton PreviousLevelButton;
    public FingerButton OpenLevelButton;
    #endregion

    [Header("Visibility Variables")]
    public bool Visible = true;

    #region Level Selection
    [Header("Level Selection")]
    private int maxElementNumber;
    private int textureNumber = 0;
    public Texture[] LevelScreen;
    static Texture currentTexture;
    static int levelNumber = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
    private int levelMax = levelNumber - 1;
    private int levelId = 0;
    #endregion

    public GameObject levelPreview;

    void OnEnable()
    {
        NextLevelButton.ButtonActivated += NextLevelButton_ButtonActivated;
        PreviousLevelButton.ButtonActivated += PreviousLevelButton_ButtonActivated;
        OpenLevelButton.ButtonActivated += OpenLevelButton_ButtonActivated;
    }

    void OnDisable()
    {
        NextLevelButton.ButtonActivated -= NextLevelButton_ButtonActivated;
        PreviousLevelButton.ButtonActivated -= PreviousLevelButton_ButtonActivated;
        OpenLevelButton.ButtonActivated -= OpenLevelButton_ButtonActivated;
    }

    void Start()
    {
        //transform.SetParent(Forearm);
        //transform.localPosition = LocalOffset;
        maxElementNumber = LevelScreen.Length - 1;
        //Debug.Log("LevelNum = " + levelNumber);
    }

    void NextLevelButton_ButtonActivated(FingerButton sender)
    {
        levelId += levelId + 1;
        if (levelId >= levelMax)
        {
            levelId = levelMax;
        }
        //Debug.Log("LevelID = " + levelId);

        if (textureNumber >= maxElementNumber) 
        {
            textureNumber = maxElementNumber;
        }
        else
            currentTexture = LevelScreen[textureNumber += 1];
    }

    void PreviousLevelButton_ButtonActivated(FingerButton sender)
    {
        levelId = levelId - 1;
        if (levelId < 0)
        {
            levelId = 0;
        }
        //Debug.Log("LevelID = " + levelId);

        if (textureNumber <= 0) 
        {
            textureNumber = 0; 
        }
        else
            currentTexture = LevelScreen[textureNumber -= 1];
    }

    void OpenLevelButton_ButtonActivated(FingerButton sender)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelId);
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, (Visible) ? Vector3.one : Vector3.zero, Time.deltaTime * 4.5f);
        levelPreview.GetComponent<Renderer>().material.mainTexture = currentTexture;
    }

    public void Show()
    {
        Visible = true;
        SetButtonVisibility(Visible);
    }

    public void Hide()
    {
        Visible = false;
        SetButtonVisibility(Visible);
    }

    public void SetButtonVisibility(bool visible)
    {
        NextLevelButton.gameObject.SetActive(Visible);
        PreviousLevelButton.gameObject.SetActive(Visible);
    }
}
