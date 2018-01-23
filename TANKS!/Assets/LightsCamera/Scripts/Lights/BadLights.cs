using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadLights : MonoBehaviour {
	
	// Public variables
	public GameObject thePlayer;		// GameObject 

	float intensityLight;
	bool openLight;
	Light mainSpot;

	// ----------------------------------------
	// Use this for initialization
	// ----------------------------------------
	void Start () {
		openLight = false;

		intensityLight = 0f;
		mainSpot = gameObject.GetComponent <Light> ();
		
	}


	// ----------------------------------------
	// Update is called once per frame
	// ----------------------------------------
	void Update () {
		if (intensityLight < 13.5f && openLight) {
			intensityLight += 0.1f;
		}

		mainSpot.intensity = intensityLight;
		
		
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

	public void lightUp () {
		openLight = true;
	}

}
