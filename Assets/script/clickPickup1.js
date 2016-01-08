var gui: GUITexture;

function OnMouseDown () {

	if (gameObject.tag == "pickable"){
		Destroy(gameObject);
		gui.GetComponent.<GUITexture>().enabled = true;
		
		
		
	}
}