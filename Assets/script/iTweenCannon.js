#pragma strict

var cannon:GameObject;
var barrel:GameObject;
var muzzle:GameObject;
var wheels:GameObject[];

var kickbackDistance:Number = .2;
var kickbackTime:Number = 2;

var explosionSound:AudioClip;

var cameraToShake:GameObject;
var cameraShakeTime:Number = .9;
var cameraShakeAmount:Number = .2;
var cameraShakeRadius:Number = 10;

var barrelSmoke:GameObject;
var barrelBlast:GameObject;

var blastLight:Light;
var lightIntensity:Number = 4;
var lightIntensityFalloff:Number = .15;

var loop:boolean = true;
var timeUntilFirstShot:Number = .5;
var loopTime:Number = 3.5;

private var currentLightIntensity:Number;

function Start () {

	if(loop){
		yield WaitForSeconds(timeUntilFirstShot);
		ShootCannon();
	}
}

function ShootCannon () {

	iTween.Stab(cannon, {"audioclip":explosionSound, "pitch":1});
	
	Instantiate(barrelSmoke, muzzle.transform.position, muzzle.transform.rotation);
	Instantiate(barrelBlast, muzzle.transform.position, muzzle.transform.rotation);
	
	iTween.PunchPosition(cannon, {"x":kickbackDistance, "time":kickbackTime});
	iTween.PunchRotation(barrel, {"y":-10, "time":kickbackTime/3});
	
	for(var i:int = 0;i<wheels.length;i++){
	
		iTween.PunchRotation(wheels[i], {"z":kickbackDistance * 250, "time":kickbackTime});
	
	}
	if(cameraToShake){
	
		var dist:float = Vector3.Distance(cameraToShake.transform.position, cannon.transform.position);
		
		if(dist < cameraShakeRadius){
		
			var shakeVolume = cameraShakeAmount/dist;
			
			iTween.PunchPosition(cameraToShake, {"y":shakeVolume, "time":cameraShakeTime});
		}
	}
	
	MuzzleFlash();
	
	if(loop)wait(loopTime);
}

function wait (waitTime){

	yield WaitForSeconds(waitTime);
	ShootCannon();
	
}

function MuzzleFlash(){

	currentLightIntensity = lightIntensity;
	
	while(currentLightIntensity >= 0){
	
		blastLight.intensity = currentLightIntensity;
		currentLightIntensity -= lightIntensityFalloff;
		
		yield;
		
	}
	
	blastLight.intensity = 0;

}