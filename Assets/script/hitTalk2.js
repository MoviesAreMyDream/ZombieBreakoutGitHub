#pragma strict
var talk: GameObject;
var talk2: GameObject;

function Start () {

}

function OnTriggerEnter (hit:Collider) {

	if(hit.gameObject.tag == "NPC2"){
		talk.GetComponent.<GUITexture>().enabled = true;
	}
	
	if(hit.gameObject.tag == "Identification"){
		talk2.GetComponent.<GUITexture>().enabled = true;
	
	}
	
}

function OnTriggerExit (hit:Collider) {

	if(hit.gameObject.tag == "NPC2"){
		Destroy(talk);
		talk2.GetComponent.<GUITexture>().enabled = false;
		GetComponent(hitTalk3).enabled = true;

}

}