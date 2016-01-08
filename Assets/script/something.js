#pragma strict

function Start () {

}

function OnTriggerEnter (hit: Collider) {
	if(hit.gameObject.tag == "Player"){
	Destroy(gameObject);
	}
}