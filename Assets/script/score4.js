var Counter : int = 0;
var kapal1 : GameObject;
var kapal2 : GameObject;
var kapal3 : GameObject;
var tulis : GameObject;
//var org : GameObject;
//var mark1 : GameObject;
//var mark2 : GameObject;
//var mark3 : GameObject;

function LateUpdate () {    
    
    tulis.GetComponent.<GUIText>().text = "Ships "+Counter +"/3";
    
    	if(kapal1.GetComponent(Rotating).enabled == true&&kapal2.GetComponent(Rotating).enabled == true&&kapal3.GetComponent(Rotating).enabled == true){
    
			Application.LoadLevel("Ending");
			print("yeah");
			    
    	}
    	
//    	if(kapal2.GetComponent(Rotating).enabled == true){
//    
//			Counter ++;
//		}
//		
//		if(kapal3.GetComponent(Rotating).enabled == true){
//    
//			Counter ++;
//		}
}
//    if(Counter >= 9){
//    kapal.guiText.enabled = false;
//    org.GetComponent(Task).enabled = false;
//    org.GetComponent(Task1).enabled = true;
// 	mark2.renderer.enabled = false;
// 	mark3.renderer.enabled = false;
//    }
//    
//}   

//function OnCollisionEnter (hit : Collision) {            
//    
//    if(hit.gameObject.tag == "cannonball"){
//    Counter++;
//    }
//    
//    if(hit.gameObject.tag == "caravan"){
//    org.GetComponent(Task2).enabled = true;
//    Destroy(GetComponent(Task1));
//    Destroy(GetComponent(TimeLimit2));
//    mark1.renderer.enabled = true;
//    }
    
//    if(hit.gameObject.tag == "door"){
//    Application.LoadLevel(3);
//    }
//}