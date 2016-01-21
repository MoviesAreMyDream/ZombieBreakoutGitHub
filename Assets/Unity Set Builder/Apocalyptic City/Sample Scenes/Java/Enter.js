 var Enter:GameObject;
 var Scene= "";
 private var Entry=false;
 function OnTriggerStay (other : Collider) {
        Enter.SetActive(true);
        
        Entry=true;
    }
    
    function OnTriggerExit (other : Collider) {
        Enter.SetActive(false);
        
        Entry=false;
    }
    
function Update () {
       if (Entry){
        
          if (Input.GetKeyDown ("e"))
			 Application.LoadLevel (Scene);
    }
    }
    
    