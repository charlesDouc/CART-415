using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCameraTilt : MonoBehaviour {

	// public variables
	public float m_TiltMin;
	public float m_TiltMax;
	public float m_TurnSpeed;
	public GameObject m_Pivot;

	// private variables
	private float m_TiltAngle;
	private Vector3 m_PivotEulers;
	private Quaternion m_PivotTargetRot;
	private float m_TurnSmoothing = 0.0f; 


	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		m_PivotEulers = m_Pivot.transform.rotation.eulerAngles;
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		HandleRotationMovement();
		
	}


	private void HandleRotationMovement()
	{
		if(Time.timeScale < float.Epsilon)
			return;

		// Read the user input
		float y = Input.GetAxis("Mouse Y");


		// on platforms with a mouse, we adjust the current angle based on Y mouse input and turn speed
		m_TiltAngle -= y*m_TurnSpeed;
		// and make sure the new value is within the tilt range
		m_TiltAngle = Mathf.Clamp(m_TiltAngle, -m_TiltMin, m_TiltMax);


		// Tilt input around X is applied to the pivot (the child of this object)
		m_PivotTargetRot = Quaternion.Euler(m_TiltAngle, 0 , 0);

		if (m_TurnSmoothing > 0)
		{
			m_Pivot.transform.localRotation = Quaternion.Slerp(m_Pivot.transform.localRotation, m_PivotTargetRot, m_TurnSmoothing * Time.deltaTime);
		}
		else
		{
			m_Pivot.transform.localRotation = m_PivotTargetRot;
		}
	}
}
