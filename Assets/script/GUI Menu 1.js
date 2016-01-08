public var labelText : String = "Find the Dutch informant and retrieve some supplies for you to inflitrate the fort.";
var style : GUIStyle;

function OnGUI () {
	GUI.Label (Rect (25, 25, 150, 100), labelText, style);
}

function OnTriggerEnter(hit : Collider){
 
 	if(hit.gameObject.tag == "ITEM1"){
 	labelText = "Tch";
 	}
}


