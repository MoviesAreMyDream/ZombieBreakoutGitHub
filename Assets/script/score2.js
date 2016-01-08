var Counter : int = 0;
var meriam : GameObject;
var org : GameObject;
var mark1 : GameObject;
var mark2 : GameObject;
var mark3 : GameObject;

function Update () {    
    meriam.GetComponent.<GUIText>().text = "Cannons "+Counter +"/9";
    
    if(Counter >= 9){
    meriam.GetComponent.<GUIText>().enabled = false;
    org.GetComponent(Task).enabled = false;
    org.GetComponent(Task1).enabled = true;
 	mark2.GetComponent.<Renderer>().enabled = false;
 	mark3.GetComponent.<Renderer>().enabled = false;
    }
    
}   

function OnTriggerEnter (hit : Collider) {            
    
    if(hit.gameObject.tag == "cannon"){
    Counter++;    
    }
    
    if(hit.gameObject.tag == "caravan"){
    org.GetComponent(Task2).enabled = true;
    Destroy(GetComponent(Task1));
    Destroy(GetComponent(TimeLimit2));
    mark1.GetComponent.<Renderer>().enabled = true;
    }
    
    if(hit.gameObject.tag == "door"){
    Application.LoadLevel("Level 3");
    }
}