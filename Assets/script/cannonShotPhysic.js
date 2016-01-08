#pragma strict

var cannonball : Transform;

function OnTriggerEnter(hit:Collider) {
    if(hit.gameObject.tag == "cannonball"){
        var projectile = Instantiate(cannonball, transform.position,transform.rotation);
        projectile.GetComponent.<Rigidbody>().AddForce(transform.right * 1000);//cannon's x axis
        Physics.IgnoreCollision(projectile.GetComponent.<Collider>(), GetComponent.<Collider>());
    }
}