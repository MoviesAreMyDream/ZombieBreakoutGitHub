//var overColor = null;  // It's nice to provide some kind of default

private var normalColor : Color;

 

function Awake () {

    normalColor = GetComponent.<GUITexture>().color;

}

 

function OnMouseEnter () { 

    GetComponent.<GUITexture>().color = Color.grey;
	GetComponent.<AudioSource>().Play();
}

 

function OnMouseExit () { 

    GetComponent.<GUITexture>().color = normalColor;

}