#pragma strict

var TheDamage : int = 20;
var Distance : float;
var MaxDistance : float = 1.5;
var Melee : Transform;
var blood : GameObject;
var Swordfx : AudioSource;

public var CanAttack : boolean = true;
public var AttackRandomizer : int = 1;

function Update(){
	
    if (CanAttack){
        if(Input.GetButtonDown("Fire1"))
        {
            if (AttackRandomizer == 1){
                Melee.GetComponent.<Animation>().Play("AttackScimitar");
            }
            if (AttackRandomizer == 2){
                Melee.GetComponent.<Animation>().Play("AttackScimitar02");
            }                    
            if (AttackRandomizer == 3) {
                Melee.GetComponent.<Animation>().Play("AttackScimitar03");
            }
                        
            AttackRandomizer = Random.Range(1,4);
            WaitForAttack();   
            AttackCoolDown();
        }
    }
}

function WaitForAttack ()
{
    CanAttack = false;
    yield WaitForSeconds(0.1f);
    Swordfx.Play();
    var hit : RaycastHit;
    if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), hit));
    {
        Distance = hit.distance;
        if (Distance < MaxDistance)
        {
            if (hit.transform.CompareTag("Zombie")) {
                hit.transform.SendMessage("ApplyDamage", TheDamage, SendMessageOptions.DontRequireReceiver);
                Instantiate(blood, hit.point, Quaternion.LookRotation(hit.normal));
            }
                
        }
    }
    
}

function AttackCoolDown () {
    yield WaitForSeconds (0.75f);
    CanAttack = true;
}



