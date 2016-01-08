var startTime = 0;
var timeLimit = 0;
var failed : GUIText;
var retry : GUIText;
var info : GUIText;
var pauseitem1 : GameObject;
var pauseitem2 : GameObject;

//function Awake(){
//
//	startTime = Time.time + timeLimit*60;
//}


function Update () {


//The time taken so far

var timeTaken = startTime - Time.time;

// Format the time nicely

GetComponent.<GUIText>().text = FormatTime (timeTaken);


if (timeTaken <= 0)

	failed.enabled = true;
 	failed.GetComponent(moveEnter).enabled = true;
	retry.GetComponent(moveEnter1).enabled = true;
	info.enabled = true;
	info.GetComponent(moveEnter2).enabled = true;
	pauseitem1.GetComponent(MouseLook).enabled = false;
	pauseitem1.GetComponent(CharacterMotor).enabled = false;
	pauseitem2.GetComponent(MouseLook).enabled = false;
	Cursor.visible = true;
	Screen.lockCursor = false;
	
}

 

 

//Format time like this

// 17[minutes]:21[seconds]:05[fraction]

 

function FormatTime (time){

 

var intTime : int = time;

var minutes : int = intTime / 60;

var seconds : int = intTime % 60;

//var fraction : int = time * 10;

// fraction = fraction % 10;

 

//Build string with format

// 17[minutes]:21[seconds]:05[fraction]

 

// timeText = minutes.ToString () ;

//timeText = timeText + seconds.ToString ();

	timeText = String.Format ("{0:00} {1:00}", minutes, seconds);

 

// timeText += fraction.ToString ();

	return timeText;

}