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



	// ---------------------------------------
	// Use this for initialization
	// ---------------------------------------
	void Start () {

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
			mainCameraScript.changeCamera (cameraIndex);

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
