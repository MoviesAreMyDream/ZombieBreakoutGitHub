var explode: GameObject;
var splash: GameObject;

//static var txtscore : int = 0;

function OnCollisionEnter (hit: Collision) {
	if(hit.gameObject.tag == "ship"){
		Instantiate(explode,transform.position, transform.rotation);
		Instantiate(splash,transform.position, transform.rotation);
		Destroy (gameObject);
		
	}
	
}	