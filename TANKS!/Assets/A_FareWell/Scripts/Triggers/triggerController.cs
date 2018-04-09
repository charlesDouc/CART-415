using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerController : MonoBehaviour {

	// public variables
	public GameObject[] m_elementToDestroy;
	public GameObject[] m_elementToActivate;

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

			// Activate the element to be activated
			if (m_elementToDestroy != null) {
				for (int i = 0; i < m_elementToActivate.Length; i++) {
					m_elementToActivate[i].SetActive(true);
				}
			}
			// Destroy the trigger
			Destroy (gameObject);
		}
	}
}
