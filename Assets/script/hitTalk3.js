#pragma strict
var talk: GameObject;
//var talk2: GameObject;

function Start () {
	GetComponent(hitTalk2).enabled = false;
}

function OnTriggerEnter (hit:Collider) {

	if(hit.gameObject.tag == "NPC2"){
		talk.GetComponent.<GUITexture>().enabled = true;
	}
	
//	if(hit.gameObject.tag == "Armor"){
//		talk2.guiTexture.enabled = true;
	
	}
	


function OnTriggerExit (hit:Collider) {

	if(hit.gameObject.tag == "NPC2"){
		talk.GetComponent.<GUITexture>().enabled = false;
//		talk2.guiTexture.enabled = false;
}

}