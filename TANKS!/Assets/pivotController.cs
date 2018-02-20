using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pivotController : MonoBehaviour {

	// public variables
	public float minTilt;
	public float maxTilt;

	// private variables
	private float m_angle;
	private float m_y = 0f;

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {

		m_y -= Input.GetAxis("Mouse Y") * 0.02f;
		m_y = ClampAngle(m_y, minTilt, maxTilt);

		// Create a new Quaternion variable with the new rotation data
		Quaternion rotation = Quaternion.Euler (m_y, 0f, 0f);

		// Update the rotation and position of the camera
		transform.rotation = rotation;


		
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	public static float ClampAngle(float angle, float min, float max) {
		if (angle < -360f) 
			angle += 360f;

		if (angle > 360f) 
			angle -= 360f;

		return Mathf.Clamp (angle, min, max);
	}
}
