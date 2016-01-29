 function Update () { 
 
 if (Input.GetKeyUp("f")){
 
 Pitch();
 
 }


    horizontal = Input.GetAxis("Horizontal"); 
    vertical = Input.GetAxis("Vertical"); 
    if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0) { 


    audio.Play();

    }

}

function Pitch () { 
 
yield WaitForSeconds(0.1);
 
 audio.pitch = 0.63;

}
    
    
    
       
    
    