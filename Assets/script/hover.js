#pragma strict

//var targetGui : GUITexture;
var hoverTex : Texture2D;
var normalTex : Texture2D;
var sfx : GameObject;
 
function OnMouseEnter() {
GetComponent.<GUITexture>().texture = hoverTex;
sfx.GetComponent.<AudioSource>().Play();
}
 
function OnMouseExit() {
GetComponent.<GUITexture>().texture = normalTex;
}