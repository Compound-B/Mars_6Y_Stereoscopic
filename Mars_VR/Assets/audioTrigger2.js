#pragma strict

var audioTrigger:AudioClip;

function OnTriggerEnter (o:Collider) {
	Debug.Log("The Trigger Fired");

	GetComponent.<AudioSource>().PlayOneShot (audioTrigger);
	
}

function OnTriggerExit (o:Collider) {
	Debug.Log("The Trigger Fired");

	GetComponent.<AudioSource>().Stop();
}

