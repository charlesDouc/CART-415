using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeZoneTrigger: MonoBehaviour {
	
	// public variables
	public int cameraIndex;
	public GameObject cameraControls;
	public bool toBeDestroyed;
	public GameObject nextTrigger;

	// private variables
	private bool goBack;



	// ---------------------------------------
	// Use this for initialization
	// ---------------------------------------
	void Start () {
		goBack = false;
	}

	// ---------------------------------------
	// Methods
	// ---------------------------------------
	void OnTriggerEnter () {
		// Get the cameras control script
		cameras_control mainCameraScript = cameraControls.GetComponent <cameras_control> ();
		// If the player is going back
		if (goBack) {
			// Change the camera with the index - 1
			mainCameraScript.changeCamera (cameraIndex - 1);
			goBack = false;
			//Debug.Log ("Camera " + cameraIndex)

		// If the player is going foward
		} else {
			// Change the camera with the index	
			mainCameraScript.changeCamera (cameraIndex);
			goBack = true;
		}

		// If the triggers need to be destroyed (changing zone)
		if (toBeDestroyed) {
			// Activate next gameobject trigger
			nextTrigger.SetActive (true);
			// Destroy this object
			Destroy (gameObject);
		}
	}
		


}
