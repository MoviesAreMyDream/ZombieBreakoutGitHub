var pause : boolean = false;
var failed : GUIText;
var retry : GUIText;
var info : GUIText;
//var exit : GUIText;
var pauseitem1 : GameObject;
var pauseitem2 : GameObject;


function OnTriggerEnter (hit : Collider) {

	if(hit.gameObject.tag == "Player"){
	
	failed.enabled = true;
	failed.GetComponent(moveEnter).enabled = true;
	retry.GetComponent(moveEnter1).enabled = true;
	info.enabled = true;
	info.GetComponent(moveEnter2).enabled = true;
//	exit.GetComponent(moveEnter1).enabled = true;
	pauseitem1.GetComponent(MouseLook).enabled = false;
	pauseitem1.GetComponent(CharacterMotor).enabled = false;
	pauseitem1.GetComponent(restart).enabled = true;
	pauseitem2.GetComponent(MouseLook).enabled = false;
	Cursor.visible = true;
	Screen.lockCursor = false;
	}
}