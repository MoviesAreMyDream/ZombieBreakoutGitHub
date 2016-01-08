var quit = false;

function OnMouseEnter () {

//	audio.Play();
	GetComponent.<Renderer>().material.color = Color.green;
}

function OnMouseExit () {

	GetComponent.<Renderer>().material.color = Color.white;
}

//function OnMouseDown(){
//
//	if(quit){
//		Application.Quit();
//	}
//	else{
//		Application.LoadLevel ("Level_1");
//		
//	}
//}