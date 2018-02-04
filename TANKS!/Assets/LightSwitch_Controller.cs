using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch_Controller : MonoBehaviour {

	// Public variables
	public GameObject myLight;
	public GameObject theTank;
	public bool begining;

	// Private variables
	private bool stop;
	private AudioSource myAudio;

	// ---------------------------------------
	// Use this for initialization
	// ---------------------------------------
	void Start () {
		// Desactivate the light and the tank (player)
		theTank.SetActive (false);
		myLight.SetActive (false);
		stop = false;
	}

	// ----------------------------------------
	// Update is called once per frame
	// ----------------------------------------
	void Update () {

		if (begining && !stop) {
			// Debug.Log ("GO");
			// Get the audiosource and play the sound
			myAudio = gameObject.GetComponent <AudioSource> ();
			myAudio.Play ();

			// Wait two seconds and open the light and activate the player
			Invoke ("OpenLight", 2f);
		}
	}

	// ---------------------------------------
	// Coroutine
	// ---------------------------------------
	void OpenLight() {
		theTank.SetActive (true);
		myLight.SetActive (true);
		stop = true;
	}
}
