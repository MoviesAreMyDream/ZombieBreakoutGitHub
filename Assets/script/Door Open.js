var rayCastHit = 2;
var dialogue: GUIText;

function Update()
{
 var hit: RaycastHit;
 dialogue.GetComponent.<GUIText>().enabled = false;
 if (Physics.Raycast(transform.position, transform.forward, hit, rayCastHit))
 {
 	if (hit.collider.gameObject.tag == "NPC")
 	{
 		dialogue.GetComponent.<GUIText>().enabled = true;
 	}
 	


 }
}