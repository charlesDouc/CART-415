using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMaster : MonoBehaviour {

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
		
	}


	// ---------------------------------------
	// Methods
	// ---------------------------------------
}
