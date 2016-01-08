//private var toggle1 :boolean = false;
//private var toggle2 :boolean = false;
//private var toggle3 :boolean = false;
//var GAMEOVER : GameObject;
public var labelText : String = "Identify all the cannons position.";
//var sword : GUITexture;
//var armor : GUITexture;
//var intel : GUITexture;
var style : GUIStyle;

function OnGUI () {
	
//	toggle1 = GUI.Toggle (Rect (25, 110, 100, 30), toggle1, "Armor", style);
//	toggle2 = GUI.Toggle (Rect (25, 130, 100, 30), toggle2, "Sword", style);
//	toggle3 = GUI.Toggle (Rect (25, 150, 100, 30), toggle3, "Identification", style);
	GUI.Label (Rect (25, 25, 150, 100), labelText, style);
 }
 
//function OnTriggerEnter(hit : Collider){
// 
// 	if(hit.gameObject.tag == "Armor"){
// 	toggle1 = true;
// 	armor.enabled = true;
// 	}
// 	
// 	if(hit.gameObject.tag == "Sword"){
// 	toggle2 = true;
// 	sword.enabled = true;
// 	}
// 	
// 	if(hit.gameObject.tag == "Identification"){
// 	toggle3 = true;
// 	intel.enabled = true;
// 	}
// }
