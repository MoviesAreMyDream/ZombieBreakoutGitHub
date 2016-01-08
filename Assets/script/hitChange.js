#pragma strict

var changeTo: GameObject;
var tukar: GameObject;
var shut1: GameObject;
var shut2: GameObject;
var turnON1: GameObject;
var turnON2: GameObject;
var turnON3: GameObject;
var turnOFF: GameObject;

function Start () {

}

function OnTriggerEnter (hit:Collider) {

	if(hit.gameObject.tag == "Player"){
		changeTo.GetComponent(MouseLook).enabled = true;
		
		tukar.GetComponent(AudioListener).enabled = true;
		tukar.GetComponent(Camera).enabled = true;
		
		shut1.GetComponent(CharacterMotor).enabled = false;
		shut1.GetComponent(MouseLook).enabled = false;
		
		shut2.GetComponent(AudioListener).enabled = false;
		shut2.GetComponent(Camera).enabled = false;
		
		turnON1.GetComponent.<GUITexture>().enabled = true;
		turnON2.GetComponent.<GUITexture>().enabled = true;
		turnON3.GetComponent.<GUITexture>().enabled = true;
		
		turnOFF.gameObject.GetComponent.<Renderer>().enabled = false;
	}

}