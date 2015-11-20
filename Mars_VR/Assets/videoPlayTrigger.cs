using UnityEngine;
using System.Collections;

public class videoPlayTrigger : MonoBehaviour {
	//An array of textures to switch between
	public Material[] Textures;
	public bool InsideCollision = false;
	MovieTexture movieFile;
	
	void Start () {
		movieFile = ((MovieTexture)GetComponent<Renderer> ().material.mainTexture);
		movieFile.Stop ();
	}
	
	//Use this trigger detection collision. Make sure you enable Is Trigger within collider in Inspector.
	//renderer.enabled Turns on/off mesh render. In this case, make sure Mesh Render has been checked off in Inspector.
	//I added a public bool for the if statement in Update
	void OnTriggerEnter(Collider other) {
		GetComponent<Renderer>().enabled = true;
		InsideCollision = true;
		movieFile.Play ();
		if(other.gameObject.name.StartsWith("Player")){
			movieFile.Play();
		}
	}
	
	//Use this to return to default state.
	//sharedMaterial is simply to return to the default non-action state. Not sure if you need this but thought I'd include it.
	void OnTriggerExit(Collider other) {
		GetComponent<Renderer>().enabled = false;
		InsideCollision = false;
		movieFile.Stop ();
		GetComponent<Renderer>().sharedMaterial = Textures [0];
	}
	
	// Update is called once per frame
	//The If statement includes if InsideCollision bool is true and an input has been made. If so, then change material
	void Update () {
		if (Input.GetKey ("space") && InsideCollision){
			GetComponent<Renderer>().sharedMaterial = Textures [1];
		}
		
	}
}
