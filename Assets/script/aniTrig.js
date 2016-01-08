#pragma strict

var ani1:GameObject;
var ani2:GameObject;
var ani3:GameObject;
var ani4:GameObject;

function Start () {

	ani1.GetComponent.<Animation>().Stop();
	ani2.GetComponent.<Animation>().Stop();
	ani3.GetComponent.<Animation>().Stop();
	ani4.GetComponent.<Animation>().Stop();
}

function OnTriggerEnter (hit:Collider) {

	if(hit.gameObject.tag == "Player"){
		
		ani1.GetComponent.<Animation>().Play();
//		ani1.AddComponent(Rigidbody);
		
		ani2.GetComponent.<Animation>().Play();
//		ani2.AddComponent(Rigidbody);
		
		ani3.GetComponent.<Animation>().Play();
//		ani3.AddComponent(Rigidbody);
		
		ani4.GetComponent.<Animation>().Play();
//		ani4.AddComponent(Rigidbody);
		
	}

}

function OnTriggerExit (hit:Collider){
	
	if(hit.gameObject.tag == "Player"){
	
		GetComponent(aniTrig).enabled = false;
	}

}