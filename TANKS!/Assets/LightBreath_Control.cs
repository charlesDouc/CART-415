using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBreath_Control : MonoBehaviour {

	// public variables
	public float minIntensity;
	public float maxIntensity;
	public float speed;
	public bool activate;

	//private variables
	private Light myLight;
	private float currentIntensity;
	private bool inhale;

	// ----------------------------------------
	// Use this for initialization
	// ----------------------------------------
	void Start () {
		// Get the light component of the object
		myLight = gameObject.GetComponent <Light> (); 

		// Set the current intensity to the minimum value
		currentIntensity = 0f;

		// Set inhale to true
		inhale = true;
	}

	// ----------------------------------------
	// Update is called once per frame
	// ----------------------------------------
	void Update () {

		// If the light is activate
		if (activate) {
			// Breathing effect
			// Inhale mouvement
			if (currentIntensity < maxIntensity && inhale) {
				// Goes bigger
				currentIntensity += speed;
				// Once done, reverse the bool to activate the other effect
			} else if (inhale) {
				inhale = false;
			}

			if (currentIntensity > minIntensity && !inhale) {
				// Goes smaller
				currentIntensity -= speed;
				// Once done, reverse the bool to activate the other effect
			} else if (!inhale) {
				inhale = true;
			}
		}

		// Update the intensity of the light with the current intensity
		myLight.intensity = currentIntensity;
	}


	// ----------------------------------------
	// Methods
	// ----------------------------------------
	void OnTriggerEnter () {
		// If the player trigger the light collider
		//Debug.Log ("COLLIDE");
		activate = true;
	}

}
