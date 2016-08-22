using UnityEngine;
using System.Collections;

public class TextureSwap : MonoBehaviour {

	
	int textureNumber = 0;
	public Texture[] textureArray;
    private int maxElementNumber; //Pastikan maxElementNumber ni kurang "1" dari saiz TextureArray atau script ni tak jalan
    Texture currentTexture;

    public LeapMenu _leapMenu;

    // Use this for initialization
    void Start () 
	{
        maxElementNumber = textureArray.Length - 1;
		currentTexture = textureArray[textureNumber];
    }
	
	// Update is called once per frame
	void Update () 
	{
        GetComponent<Renderer>().material.mainTexture = currentTexture;
        currentTexture = textureArray[textureNumber+=1];

        if (Input.GetKeyDown("z")) 
        {
			if (textureNumber >= maxElementNumber) //stupid workaround to prevent "Array index is out of range" error, complicated sket nak explain Zu :P
			{
				textureNumber = maxElementNumber; //stupid workaround to prevent "Array index is out of range" error, complicated sket nak explain Zu :D
			}
			else
				currentTexture = textureArray[textureNumber+=1];
		}
			
		if (Input.GetKeyDown("x")) 
		{
			if (textureNumber <= 0) //stupid workaround to prevent "Array index is out of range" error, complicated sket nak explain Zu :V
			{
				textureNumber = 0; //stupid workaround to prevent "Array index is out of range" error, complicated sket nak explain Zu :O
			}
			else
				currentTexture = textureArray[textureNumber-=1];
		}

    }
}
