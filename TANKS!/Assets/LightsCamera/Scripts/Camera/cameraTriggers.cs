using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTriggers : MonoBehaviour {
	
	// public variables
	public int cameraIndex;
	public GameObject cameraControls;
	public GameObject nextTrigger;
	public bool toBeDestroyed;
	public GameObject objectsThatNeedToBeSpawn;
	public GameObject desactivate;

	// private variables
	private bool goBack;



	// ---------------------------------------
	// Use this for initialization
	// ---------------------------------------
	void Start () {
		goBack = false;

		// If there's any objects that needs to be spawn
		if (objectsThatNeedToBeSpawn != null) {
			objectsThatNeedToBeSpawn.SetActive (false);
		}
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

		// If there's any objects that needs to be spawn
		if (objectsThatNeedToBeSpawn != null) {
			objectsThatNeedToBeSpawn.SetActive (true);
		}

		// If there's any objects that needs to be desactivate
		if (desactivate != null) {
			desactivate.SetActive (false);
		}
	}
		


}
