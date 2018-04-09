using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalCamera : MonoBehaviour {

	// public variables
	public Transform playerCamera;
	public Transform portal;
	public Transform otherPortal;


	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		Vector3 PlayerOffsetFromPortal = playerCamera.position - otherPortal.position;
		transform.position = portal.position + PlayerOffsetFromPortal;

		float angularDiffBetweenPoralRotation = Quaternion.Angle (portal.rotation, otherPortal.rotation);

		Quaternion portalRotationDiff = Quaternion.AngleAxis (angularDiffBetweenPoralRotation, Vector3.up);
		Vector3 newCamDirection = portalRotationDiff * playerCamera.forward;
		transform.rotation = Quaternion.LookRotation (newCamDirection, Vector3.up);
	}

}
