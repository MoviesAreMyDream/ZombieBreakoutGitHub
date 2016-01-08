
private var dead = false;

function OnCollisionEnter ( hit: Collision) {
	if(hit.gameObject.tag == "cannonball"){
		dead = true;
		BossHPcontrol2.BOSSLIVES -= 1;
	}
	
}