#pragma strict

//how long we wait before we react
var WaitTime = 1.0;
 
// Internal time when key was pressed
private var DownTime : float;
private var isHandled : boolean = false;
var portal: GameObject;
 
function Update ()
{
    if (Input.GetKeyDown ("b"))
    { //Key was pressed down, so take up time.
        DownTime = Time.time;
        isHandled = false;
    }
   if (Input.GetKey("b")) // is key still being hold down...
    {  
        // And is it been hold over the time we want and is not handled yet?
        if((Time.time > DownTime + WaitTime))
        {
            // We've been here, don't do this again until button is pressed again.
            isHandled = true;
            // Do Something here
            Debug.Log("Key \"B\" was pressed over " + WaitTime +" seconds.") ;
            portal.active = false;
            
        }
    }
}

function OnTriggerStay(other:Collider)
{
	if(other.gameObject.tag == "Portal")
	{
		Debug.Log("Porrtaaaaalllll!!!");
	}
}
