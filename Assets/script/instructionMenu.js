var label: GUITexture;

function OnMouseDown () {

if(gameObject.tag == "intro"){
	Screen.lockCursor = false;
	label.GetComponent.<GUITexture>().enabled = true;
	}
}