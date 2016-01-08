static var timeLimit = 2.5; //in minutes
static var startTime;
static var textTime : String; //added this member variable here so
//we can access it through other scripts
var style : GUIStyle;
var failed : GUIText;
var pauseitem1 : GameObject;
var pauseitem2 : GameObject;
var retry : GUIText;
var info : GUIText;
        
function Awake() {
    
	startTime = Time.time + timeLimit*60;

}

          
function OnGUI () {
     
var timeLeft = startTime - Time.time;
var minutes : int = timeLeft / 60;
var seconds : int = timeLeft % 60;
//var fraction : int = (timeLeft * 100) % 100;
  
textTime = "Time Left: " + String.Format("{0:00}:{1:00}", minutes,seconds); 
     
GUI.Label (Rect (610, 20, 200, 600), textTime, style);         


	if(timeLeft <= 0){
	failed.enabled = true;
	failed.GetComponent(moveEnter).enabled = true;
	retry.GetComponent(moveEnter1).enabled = true;
	info.enabled = true;
	info.GetComponent(moveEnter2).enabled = true;
	pauseitem1.GetComponent(MouseLook).enabled = false;
	pauseitem1.GetComponent(CharacterMotor).enabled = false;
	pauseitem1.GetComponent(restart).enabled = true;
	pauseitem2.GetComponent(MouseLook).enabled = false;
//	pauseitem1.GetComponent(TimeLimit2).enable = false;
//	Screen.showCursor = true;
//	Screen.lockCursor = false;
	}
	
//	if(Input.GetButton("Fire1")){
//		textTime = "Time Left: " + String.Format("{0:00}:{1:00}", minutes,seconds); 
//	}
}


