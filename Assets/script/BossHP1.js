
private var dead = false;

function OnCollisionEnter ( hit: Collision) {
	if(hit.gameObject.tag == "cannonball"){
		dead = true;
		BossHPcontrol1.BOSSLIVES -= 1;
	}
	
}