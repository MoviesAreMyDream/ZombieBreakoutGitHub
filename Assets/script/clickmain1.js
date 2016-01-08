var quit = false;

function OnMouseDown(){

	if(quit){
		Application.Quit();
	}
	else{
		Application.LoadLevel ("MainMenu");
		
	}
}