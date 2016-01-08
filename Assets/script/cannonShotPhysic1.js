#pragma strict

var cannonball : Transform;

function Update() {
    if(Input.GetButtonUp("Fire1")) {
        var projectile = Instantiate(cannonball,
                                     transform.position,
                                     transform.rotation);
        projectile.GetComponent.<Rigidbody>().AddForce(transform.right * 2500);//cannon's x axis
        //Physics.IgnoreCollision(projectile.GetComponent.<Collider>(), GetComponent.<Collider>());
    }
    
}