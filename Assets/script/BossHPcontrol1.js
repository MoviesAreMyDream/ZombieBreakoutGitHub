var health1 : Texture2D;
var health2 : Texture2D;
var health3 : Texture2D; 
//var health4 : Texture2D;
//var health5 : Texture2D;
//var health6 : Texture2D;
//var health7 : Texture2D;
//var health8 : Texture2D;
//var health9 : Texture2D;
//var health10 : Texture2D;
//var health11 : Texture2D;
//var health12 : Texture2D;
//var health13 : Texture2D;
//var health14 : Texture2D;
//var health15 : Texture2D;
//var health16 : Texture2D;
//var health17 : Texture2D;
//var health18 : Texture2D;
//var health19 : Texture2D;
//var health20 : Texture2D;
//var explode: Transform;
var crash1: GameObject;
//var crash2: GameObject;
//var crash3: GameObject;
var hidup1: GameObject;
var hidup2: GameObject;

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
//		case 20:
//			guiTexture.texture = health20;
//		break;
//		
//		case 19:
//			guiTexture.texture = health19;
//		break;
//			
//		case 18:
//			guiTexture.texture = health18;
//		break;
//					
//		case 17:
//			guiTexture.texture = health17;
//		break;
//			
//		case 16:
//			guiTexture.texture = health16;
//		break;
//			
//		case 15:
//			guiTexture.texture = health15;	
//		break;
//			
//		case 14:
//			guiTexture.texture = health14;
//		break;
//			
//		case 13:
//			guiTexture.texture = health13;
//		break;
//			
//		case 12:
//			guiTexture.texture = health12;
//		break;
//					
//		case 11:
//			guiTexture.texture = health11;
//		break;
//			
//		case 10:
//			guiTexture.texture = health10;
//		break;
//			
//		case 9:
//			guiTexture.texture = health9;
//		break;
//					
//		case 8:
//			guiTexture.texture = health8;
//		break;
//			
//		case 7:
//			guiTexture.texture = health7;
//		break;
//			
//		case 6:
//			guiTexture.texture = health6;	
//		break;
//			
//		case 5:
//			guiTexture.texture = health5;
//		break;
//			
//		case 4:
//			guiTexture.texture = health4;
//		break;
//			
		case 3:
			GetComponent.<GUITexture>().texture = health3;	
		break;
			
		case 2:
			GetComponent.<GUITexture>().texture = health2;
			hidup1.gameObject.active = true;
			hidup2.gameObject.active = true;
		break;
			
		case 1:
			GetComponent.<GUITexture>().texture = health1;
		break;	
		
		case 0:
			//gameover script here
				
//				crash1.GetComponent(Animation).enabled = false;
				crash1.GetComponent(BoxCollider).enabled = false;
				crash1.GetComponent(Rotating).enabled = true;
				crash1.GetComponent.<Animation>().Stop();
				
//				crash2.GetComponent(Animation).enabled = false;
//				crash2.GetComponent(BoxCollider).enabled = false;
//				
//				crash3.GetComponent(Animation).enabled = false;
//				crash3.GetComponent(BoxCollider).enabled = false;
				
				GetComponent.<GUITexture>().enabled = false;
		
		
		break;
	}
	}
	

	

	
	


