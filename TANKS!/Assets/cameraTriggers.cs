using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTriggers : MonoBehaviour {
	
	// public variables
	public int cameraIndex;
	public GameObject cameraControls;

	// private variables
	private bool goBack;



	// ---------------------------------------
	// Use this for initialization
	// ---------------------------------------
	void Start () {
		goBack = false;
	}

	// ---------------------------------------
	// Update is called once per frame
	// ---------------------------------------
	void Update () {
		
	}

	// ---------------------------------------
	// Methods
	// ---------------------------------------
	void OnTriggerEnter () {
		cameras_control mainCameraScript = cameraControls.GetComponent <cameras_control> ();
		if (goBack) {
			mainCameraScript.changeCamera (cameraIndex - 1);
			goBack = false;
			Debug.Log ("Camera " + cameraIndex);
		} else {
			mainCameraScript.changeCamera (cameraIndex);
			goBack = true;
		}
	}
		


}
