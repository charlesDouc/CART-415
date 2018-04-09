using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightControl : MonoBehaviour {

	// Public variables
	public GameObject torchlight;		// GameObject ref to the torchlight
	public GameObject redAntenna;		// GameObject ref to the red antenna
	public GameObject greenAntenna;		// GameObject ref to the green antenna

	// Private variables
	bool onOff;							// Torchlight switch (on/off)
	public bool antennaStatus;			// Antenna status (seen or hide / red or green)

	
	// ----------------------------------------
	// Use this for initialization
	// ----------------------------------------
	void Start () {
		// Set the original statue of the torchlight to on
		onOff = true;
	}

	// ----------------------------------------
	// Update is called once per frame
	// ----------------------------------------
	void Update () {
		
		// When space key is pressed, switch the statue of the torchlight
		if (Input.GetKeyDown(KeyCode.Space)) {
			onOff = !onOff;
			// Debug.Log ("SWITCH");
		}

		// Update the status of the torchlight
		torchlight.SetActive(onOff);


		// Update the status of the antenna
		if (antennaStatus) {
			// Set the green light
			greenAntenna.SetActive(true);
			redAntenna.SetActive(false);
		} else {
			// Set the red light
			greenAntenna.SetActive(false);
			redAntenna.SetActive(true);
		}
		
	}
}
