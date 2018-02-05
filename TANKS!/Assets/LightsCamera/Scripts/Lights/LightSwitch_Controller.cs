using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch_Controller : MonoBehaviour {

	// Public variables
	public GameObject myLight;
	public GameObject theTank;
	public bool begining;
	public GameObject theGameMaster;

	// Private variables
	private bool stop;
	private AudioSource myAudio;

	// ---------------------------------------
	// Use this for initialization
	// ---------------------------------------
	void Start () {
		// Make sure this happens at the begining
		if (begining) {
			// Desactivate the light and the tank (player)
			theTank.SetActive (false);
			myLight.SetActive (false);
			stop = false;
		}

		myAudio = gameObject.GetComponent <AudioSource> ();
	}

	// ----------------------------------------
	// Update is called once per frame
	// ----------------------------------------
	void Update () {

		if (begining && !stop) {
			// Debug.Log ("GO");
			// Get the audiosource and play the sound
			myAudio.Play ();

			// Wait two seconds and open the light and activate the player
			Invoke ("OpenLight", 2f);
		}
			
	}

	// ---------------------------------------
	// Methods
	// ---------------------------------------
	void OpenLight() {
		theTank.SetActive (true);
		myLight.SetActive (true);
		stop = true;
	}

	void closeLight() {
		// Desactivate the tank and the light
		theTank.SetActive (false);
		myLight.SetActive (false);
	}

	void OnTriggerEnter() {
		// Make sure this is the end gate
		if (!begining) {
			// Play the switch sound
			myAudio.Play ();

			// Close the light and all
			Invoke("closeLight", 0.4f);
			// After 10 second, call the end of the game
			Invoke ("theEnd", 10f);
		}

	}

	void theEnd() {
		// Get the method in the gm to reload the game
		gameMaster gmScript = theGameMaster.GetComponent<gameMaster> ();
		gmScript.reload ();
	}
}
