var waypoint : Transform[];
var speed : float = 20;
private var currentWaypoint: int;
var loop : boolean = true;


//function Awake(){

//	waypoint[0] = transform;

//}

function Update(){
	
	if (currentWaypoint < waypoint.length){
		
		var target : Vector3 = waypoint[currentWaypoint].position;
		var moveDirection : Vector3 = target - transform.position;
		var velocity = GetComponent.<Rigidbody>().velocity;
		
		if(moveDirection.magnitude < 1 ){
			currentWaypoint++;
		}
		
		else{
			velocity = moveDirection.normalized * speed;
		}	
	
	}
	
	else{
	
		if(loop){
		
		currentWaypoint = 0;
		
		}
		
		else {
		
		velocity = Vector3.zero;
		
		}
	
	}

	
	GetComponent.<Rigidbody>().velocity = velocity;
	transform.LookAt(target);

}