#pragma strict
var rotSpeed : float = 2;

function FixedUpdate () {
	transform.Rotate(0, rotSpeed,0);
}