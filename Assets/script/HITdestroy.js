var buang : GameObject;
//var buang2 : GameObject;

function OnTriggerEnter (hit : Collider) {

	if(hit.gameObject.tag == "Player"){
	Destroy(buang);
//	Destroy(buang2);
//	Debug.Log("hit");
	}
}