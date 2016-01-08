//public var labelText : String = "Find all the cannon being placed before time runs out.";
//var style : GUIStyle;
var pauseitem1 : GameObject;
var pauseitem2 : GameObject;
//var pauseitem3 : GameObject;
//var pauseitem3 : GameObject;
var task : GUITexture;
var click : GUIText;
var show : GUIText;
//var turnOff : GUIText;

function Awake(){

	pauseitem1.GetComponent(MouseLook).enabled = false;
	pauseitem1.GetComponent(CharacterMotor).enabled = false;
	pauseitem2.GetComponent(MouseLook).enabled = false;
//	pauseitem3.GetComponent(MouseLook).enabled = false;
//	pauseitem1.GetComponent(GUIMenu3).enabled = false;
}

//function OnGUI () {
//	
//	GUI.Label (Rect (550, 200, 300, 200), labelText, style);
//	
// 	if(GUI.Button (Rect (650, 320, 80, 50), "Start")){
// 		pauseitem1.GetComponent(TimeLimit2).enabled = true;
// 	}		
//	
//}

function Update(){

	if(Input.GetButton("Fire1")){
		pauseitem1.GetComponent(MouseLook).enabled = true;
		pauseitem1.GetComponent(CharacterMotor).enabled = true;
		pauseitem1.GetComponent(TimeLimit2).enabled = true;
		pauseitem1.GetComponent(Task).enabled = true;
		pauseitem2.GetComponent(MouseLook).enabled = true;
//		pauseitem3.GetComponent(MouseLook).enabled = true;
		task.GetComponent.<GUITexture>().enabled = true;
		click.GetComponent.<GUIText>().enabled = false;
		show.GetComponent.<GUIText>().enabled = true;
//		turnOff.enabled = false;
	}
	
}

//function OnTriggerEnter(hit : Collider){
// 
// 	if(hit.gameObject.tag == "ITEM1"){
// 	labelText = "Tch";
// 	}
//}


