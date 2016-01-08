var gui: GUITexture;
var pauseitem1: GameObject;
var pauseitem2: GameObject;
var instruction: GUITexture;
var exit: GUITexture;
var resume: GUITexture;
var pausetext: GUITexture;
var label: GUITexture;

function OnMouseDown () {

	if (gameObject.tag == "resume"){
		
		Time.timeScale = 1;
		instruction.GetComponent.<GUITexture>().enabled = false;
		exit.GetComponent.<GUITexture>().enabled = false;
		resume.GetComponent.<GUITexture>().enabled = false;
		pausetext.GetComponent.<GUITexture>().enabled = false;
		pauseitem1.GetComponent(MouseLook).enabled = true;
		pauseitem2.GetComponent(MouseLook).enabled = true;
		Screen.lockCursor = true;
		label.GetComponent.<GUITexture>().enabled = false;
		Cursor.visible = false;
		
	}
}