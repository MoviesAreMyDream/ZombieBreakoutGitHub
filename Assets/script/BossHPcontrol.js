var health1 : Texture2D;
var health2 : Texture2D;
var health3 : Texture2D; 
var health4 : Texture2D;
var health5 : Texture2D;
//var crash1: GameObject;
//var crash2: GameObject;
//var crash3: GameObject;
//var hidup1: GameObject;
//var hidup2: GameObject;

static var BOSSLIVES = 3;
static var HITS = 0;

function Update () 
{
	//if (HITS) {
	//Instantiate(explode,transform.position, transform.rotation);
	//	Destroy (gameObject);
	//}
	switch(BOSSLIVES)
	{
		case 5:
			GetComponent.<GUITexture>().texture = health5;	
		break;
		
		case 4:
			GetComponent.<GUITexture>().texture = health4;	
		break;
		
		case 3:
			GetComponent.<GUITexture>().texture = health3;	
		break;
			
		case 2:
			GetComponent.<GUITexture>().texture = health2;
			//hidup1.gameObject.active = true;
			//hidup2.gameObject.active = true;
		break;
			
		case 1:
			GetComponent.<GUITexture>().texture = health1;
		break;	
		
		case 0:
			//gameover script here
				
//				crash1.GetComponent(Animation).enabled = false;
//				crash1.GetComponent(BoxCollider).enabled = false;
//				crash1.GetComponent.<Animation>().Stop();
//				crash1.animation.wrapMode = WrapMode.Once;
//				crash1.GetComponent(Rotating).enabled = true;
				
//				crash2.GetComponent(Animation).enabled = false;
//				crash2.GetComponent(BoxCollider).enabled = false;
//				
//				crash3.GetComponent(Animation).enabled = false;
//				crash3.GetComponent(BoxCollider).enabled = false;
				
//				GetComponent.<GUITexture>().enabled = false;
		
		
		break;
	}
	}
	

	

	
	


