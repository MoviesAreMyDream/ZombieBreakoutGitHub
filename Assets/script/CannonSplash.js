#pragma strict

var pom : GameObject;


function OnCollisionEnter (hit : Collision) {
//
//	if(hit.gameObject.tag == "pBullet"){
//	Destroy(gameObject);
//	}
	if(hit.gameObject.tag == "water"){
	Instantiate(pom,transform.position, transform.rotation);
	Destroy(gameObject);
	}

}