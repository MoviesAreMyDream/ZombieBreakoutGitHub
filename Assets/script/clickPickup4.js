var gui: GUITexture;
var gui2: GUITexture;
var button1: GUITexture;
var button2: GUITexture;
var scene: GUITexture;
var scene1: GUITexture;

function OnMouseDown () {

	if (gameObject.tag == "pickable"){
//		Destroy(gameObject);
		gui.GetComponent.<GUITexture>().enabled = true;
		gui2.GetComponent.<GUITexture>().enabled = false;
		button1.GetComponent.<GUITexture>().enabled = false;
		button2.GetComponent.<GUITexture>().enabled = true;
		scene.GetComponent.<GUITexture>().enabled = false;
		scene1.GetComponent.<GUITexture>().enabled = true;
		
		
	}
}