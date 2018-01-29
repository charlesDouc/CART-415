using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameras_control : MonoBehaviour {

	// public variables
	public GameObject[] cameraNumber;

	// private variables
	private int currentCamera;


	// ---------------------------------------
	// Use this for initialization
	// ---------------------------------------
	void Start () {
		// Disabled all other cameras in the scene
		for (int i = 0; i < cameraNumber.Length; i++) {
			cameraNumber[i].SetActive(false);
			// Debug.Log ("Camera " + i + " disabled!");
		}

		// Set the first camera true
		cameraNumber[0].SetActive(true);
		currentCamera = 0;
	}

	// ---------------------------------------
	// Update is called once per frame
	// ---------------------------------------
	void Update () {
		
	}

	// ---------------------------------------
	// Methods
	// ---------------------------------------
	public void changeCamera (int index) {
		cameraNumber [currentCamera].SetActive (false);
		cameraNumber [index].SetActive (true);

		currentCamera = index;
	}
}
