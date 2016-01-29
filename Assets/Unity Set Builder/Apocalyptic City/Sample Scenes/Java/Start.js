var Start:GameObject;
var Menu:GameObject;



	
	function OnMouseOver() 
	{		
		renderer.material.color = Color.green;
    }
	function OnMouseExit() 
	{
		renderer.material.color = Color.white;
    }
	function OnMouseDown() 
	{

Start.SetActive(true);
Menu.SetActive(false);
    }      