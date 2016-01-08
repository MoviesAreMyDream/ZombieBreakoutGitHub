//var overColor = null;  // It's nice to provide some kind of default

//private var normalColor : Color;

 

//function Awake () {
//
//    normalColor = guiTexture.color;
//
//}

 

function OnMouseEnter () { 

    iTween.scaleTo(gameObject,{"x":1},{"y":1});
	GetComponent.<AudioSource>().Play();
}

 

//function OnMouseExit () { 
//
//    guiTexture.color = normalColor;
//
//}