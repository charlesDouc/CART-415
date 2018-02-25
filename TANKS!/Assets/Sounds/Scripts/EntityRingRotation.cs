using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityRingRotation : MonoBehaviour {

	// public variables
	public bool horaire;
	public float m_rotationSpeed;

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		// Change the value depending on rotation orientation
		if (!horaire) {
			m_rotationSpeed = -m_rotationSpeed;
		}
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		// Rotate the object based on speed value
		gameObject.transform.Rotate (0, m_rotationSpeed * Time.deltaTime, 0);
		
	}
}
