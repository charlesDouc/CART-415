using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigSphere_Controller : MonoBehaviour {

	// private variables
	private float scaleMeter;

	// ---------------------------------------
	// Use this for initialization
	// ---------------------------------------
	void Start () {
		
	}

	// ---------------------------------------
	// Update is called once per frame
	// ---------------------------------------
	void Update () {
		// Create a new vector 3
		Vector3 currentScale;
		// Get the info of the scale
		scaleMeter = transform.localScale.x;

		// Bigger scale until a certain point
		if (scaleMeter < 43f) {
			// Get the scale up
			scaleMeter += 0.05f;
		}

		// Set new data to current scale 
		currentScale = new Vector3 (scaleMeter, scaleMeter, scaleMeter);

		// Update the scale of the object
		transform.localScale = currentScale;
	}
}
