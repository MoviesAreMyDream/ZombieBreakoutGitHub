var colorStart = Color.red;
var colorEnd = Color.green;
var duration = 3.0;

 function Update () {
     var lerp = Mathf.PingPong (Time.time, duration) / duration;
     GetComponent.<Renderer>().material.color = Color.Lerp (colorStart, colorEnd, lerp);
     
 }