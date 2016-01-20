var Start:GameObject;
var Menu:GameObject;

	function OnMouseOver() 
	{		
		GetComponent<Renderer>().material.color = Color.green;
    }
	function OnMouseExit() 
	{
		GetComponent<Renderer>().material.color = Color.white;
    }
	function OnMouseDown() 
	{
		Start.SetActive(true);
		Menu.SetActive(false);
    }      