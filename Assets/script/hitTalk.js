#pragma strict
var talk: GameObject;
var talk2: GameObject;

function Start () {

}

function OnTriggerEnter (hit:Collider) {

	if(hit.gameObject.tag == "NPC1"){
		talk.GetComponent.<GUITexture>().enabled = true;
	}
	
	if(hit.gameObject.tag == "Armor"){
		talk2.GetComponent.<GUITexture>().enabled = true;
	
	}
	
}

function OnTriggerExit (hit:Collider) {

	if(hit.gameObject.tag == "NPC1"){
		Destroy(talk);
		talk2.GetComponent.<GUITexture>().enabled = false;
		GetComponent(hitTalk1).enabled = true;

}

}