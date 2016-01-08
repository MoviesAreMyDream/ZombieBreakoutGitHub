
private var dead = false;

function OnCollisionEnter ( hit: Collision) {
	if(hit.gameObject.tag == "zombie"){
		dead = true;
		BossHPcontrol.BOSSLIVES -= 1;
	}
	
}