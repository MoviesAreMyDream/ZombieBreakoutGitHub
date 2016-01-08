#pragma strict

var minTime = .5;
var thresh = .5;

private var lastTime = 0;
private var myLight;

function Start()
{
    myLight = GetComponent(Light);
}

function Update ()
{

    if ((Time.time - lastTime) > minTime)
        if (Random.value > thresh)
            GetComponent.<Light>().enabled = true;
        else
            GetComponent.<Light>().enabled = false;
    lastTime = Time.time;
}