using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectionLevelManager : MonoBehaviour {

	//public variables
	public GameObject[] zones;

	// ---------------------------------------
	// Use this for initialization
	// ---------------------------------------
	void Start () {
		// Disabled all zones
		for (int i = 0; i < zones.Length; i++) {
			zones[i].SetActive(false);
			Debug.Log ("Zone " + i + " disabled!");
		}

		// Set the first and second zone active
		zones[0].SetActive(true);
		zones[1].SetActive(true);
	}


	// ---------------------------------------
	// Update is called once per frame
	// ---------------------------------------
	void Update () {

		// Set the ESC key to quit the application
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
		
	}


	// ---------------------------------------
	// Methods
	// ---------------------------------------
	public void reload () {
		// Reload the game (scene)
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
