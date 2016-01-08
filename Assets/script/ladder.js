//var org : GameObject;

function OnTriggerEnter (other : Collider) 
    { 
        if(other.gameObject.tag == "ladder")
        {
//            org.GetComponent(CharacterController).slopeLimit = 85; 
			transform.position += Vector3(0,80,0);
		}
	}