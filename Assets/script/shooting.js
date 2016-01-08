var projectile : Rigidbody;
var speed = 10;


function Update () {

//	if ( Input.GetButtonUp ("Fire1")) {

	clone = Instantiate(projectile, transform.position, transform.rotation);
	clone.velocity = transform.TransformDirection( Vector3 (0, 0, speed));
//	audio.Play();
	Destroy (clone.gameObject, 0.3);

//	}
}
