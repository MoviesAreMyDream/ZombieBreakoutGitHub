﻿var target : Transform; 
var moveSpeed = 3; 
var rotationSpeed = 3; 
  
var myTransform : Transform; //current transform data of this enemy
  
function Awake()
{
    myTransform = transform; //cache transform data for easy access/preformance
}
  
function Start()
{
    target = GameObject.FindWithTag("Player").transform; //target the player 
}
  
function Update () {
    myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
    Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
  
    //move towards the player
    myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;  
}