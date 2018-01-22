using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadLights : MonoBehaviour {
	
	// Public variables
	public GameObject thePlayer;		// GameObject 


	// ----------------------------------------
	// Use this for initialization
	// ----------------------------------------
	void Start () {
		
	}


	// ----------------------------------------
	// Update is called once per frame
	// ----------------------------------------
	void Update () {
		
		
	}

	// ----------------------------------------
	// Methods
	// ----------------------------------------
	void OnTriggerEnter() {
		// Get the antennaStatus of the tank light
		lightControl TankLightScript = thePlayer.GetComponent <lightControl> ();
		TankLightScript.antennaStatus = false;
		//Debug.Log ("Enter");
	}

	void OnTriggerExit() {
		// Get the antennaStatus of the tank light
		lightControl TankLightScript = thePlayer.GetComponent <lightControl> ();
		TankLightScript.antennaStatus = true;
		//Debug.Log ("Enter");
	}

}
