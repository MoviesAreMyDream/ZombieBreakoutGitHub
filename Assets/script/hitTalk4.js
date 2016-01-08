#pragma strict
var talk: GameObject;
var talk2: GameObject;

function Start () {

}

function OnTriggerEnter (hit:Collider) {

	if(hit.gameObject.tag == "NPC3"){
		talk.GetComponent.<GUITexture>().enabled = true;
	}
	
	if(hit.gameObject.tag == "Sword"){
		talk2.GetComponent.<GUITexture>().enabled = true;
	
	}
	
}

function OnTriggerExit (hit:Collider) {

	if(hit.gameObject.tag == "NPC3"){
		Destroy(talk);
		talk2.GetComponent.<GUITexture>().enabled = false;
		GetComponent(hitTalk5).enabled = true;
		

}

}