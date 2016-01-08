var pause: boolean = false;
var pauseitem1: GameObject;
var pauseitem2: GameObject;
var instruction: GUITexture;
var exit: GUITexture;
var resume: GUITexture;
var pausetext: GUITexture;
var label: GUITexture;
var log: boolean = false;
var mission: GUITexture;


function Update () {

	if(Input.GetKeyDown("escape")){
		
		if(!pause){
			Time.timeScale = 0;
			pause = true;
			
			instruction.GetComponent.<GUITexture>().enabled = true;
			exit.GetComponent.<GUITexture>().enabled = true;
			resume.GetComponent.<GUITexture>().enabled = true;
			pauseitem1.GetComponent(MouseLook).enabled = false;
			pauseitem2.GetComponent(MouseLook).enabled = false;
			pausetext.GetComponent.<GUITexture>().enabled = true;
			Cursor.visible = true;
			Screen.lockCursor = false;
			
		}
		else{
			Time.timeScale = 1;
			pause = false;
			
			instruction.GetComponent.<GUITexture>().enabled = false;
			exit.GetComponent.<GUITexture>().enabled = false;
			resume.GetComponent.<GUITexture>().enabled = false;
			pausetext.GetComponent.<GUITexture>().enabled = false;
			pauseitem1.GetComponent(MouseLook).enabled = true;
			pauseitem2.GetComponent(MouseLook).enabled = true;
			label.GetComponent.<GUITexture>().enabled = false;
			Cursor.visible = false;
			Screen.lockCursor = true;
			}
		}
		
	if(Input.GetKeyDown(KeyCode.M)){
	
		if(!log){
		
			log = true;
			
			mission.GetComponent.<GUITexture>().enabled = true;
		}
		
		else{
		
		log = false;
		
		mission.GetComponent.<GUITexture>().enabled = false;
	}
}

}