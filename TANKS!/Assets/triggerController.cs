using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerController : MonoBehaviour {

	// public variables
	public GameObject[] m_elementToDestroy;

	// private variables


	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		
	}


	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		
	}


	// ------------------------------------
	// Methods
	// ------------------------------------
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player") {
			// Destroy the element to be destroyed
			if (m_elementToDestroy != null) {
				for (int i = 0; i < m_elementToDestroy.Length; i++) {
					Destroy (m_elementToDestroy[i]);
				}
			}
			// Destroy the trigger
			Destroy (gameObject);
		}
	}
}
