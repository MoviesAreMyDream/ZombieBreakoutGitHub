var laa : GameObject;

function OnMouseDown(){

	laa.GetComponent.<GUITexture>().enabled = true;
	
	
}

function Update(){

	if(Input.GetKeyDown(KeyCode.Escape)){
	laa.GetComponent.<GUITexture>().enabled = false;
	}
}