#pragma strict
//var emit: boolean;

//function Start () {

// Emit particles for 3 seconds
GetComponent.<ParticleEmitter>().emit = true;
yield WaitForSeconds(2);
// Then stop
GetComponent.<ParticleEmitter>().emit = false;

//}

function Update () {

//yield WaitForSeconds (1);
// print (Time.time);
}