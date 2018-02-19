using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSoundControllerImproved : MonoBehaviour {
	
	/* 
	* -------------------------------------------------------------------------
	* This script is for the rotation of the camera around the player
	* It has been tweak from this original script available at this website:
	* http://wiki.unity3d.com/index.php?title=MouseOrbitImproved#Code_C.23
	* -------------------------------------------------------------------------
	*/ 

	// public variables
	public Transform thePlayer;			// The tank player
	public float distance = 5f; 		// Distance between the camera and the player
	public float xSpeed = 120f;			// Speed mouvement on the X axis
	public float ySpeed = 120f;			// Speed mouvement on the Y axis
	public float yMinLimit = -20f;		// Minimum height of the camera
	public float yMaxLimit = 80f;		// Maximum height of the camera
	public float distanceMin = 0.5f;	// Minimum distance
	public float distanceMax = 15f;		// Maximum distance

	// private variables
	private Rigidbody theRB;			// Rigidbody if there's one on the camera
	private float my_X = 0f;			// X from this object
	private float my_Y = 0f;			// Y from this object


	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		// Get the data of this object euler angles
		Vector3 angles = transform.eulerAngles;
		// Initiate my_X and my_Y with the current euler angles
		my_X = angles.y;
		my_Y = angles.x;

		// Get the rigidbody of the game object
		theRB = GetComponent<Rigidbody> ();

		// If there's a rigidbody
		if (theRB != null) {
			theRB.freezeRotation = true;
		}
	}
		
	// ------------------------------------
	//  Is called after all Update functions
	// ------------------------------------
	void LateUpdate () {

		// Make the rotation around the player happen based on the mouse mouvements
		my_X += Input.GetAxis ("Horizontal_Mouse") * xSpeed * 0.02f;
		my_Y -= Input.GetAxis ("Vertical_Mouse") * ySpeed * 0.02f;

		// Return a new value for my_Y from the ClampAngle method
		my_Y = ClampAngle (my_Y, yMinLimit, yMaxLimit);

		// Create a new Quaternion variable with the new rotation data
		Quaternion rotation = Quaternion.Euler (my_Y, my_X, 0);

		/*	Not using the zoom feature
		distance = Mathf.Clamp (distance - Input.GetAxis ("Mouse_ScrollWheel") * 5, distanceMin, distanceMax);
		*/

		RaycastHit hit;
		if (Physics.Linecast (thePlayer.position, transform.position, out hit)) {
			distance -= hit.distance;
		}

		// Create a new variable for the negative distance
		Vector3 negDistance = new Vector3 (0f, 0f, -distance);
		// Enter new position value based on where the player object is
		Vector3 position = rotation * negDistance + thePlayer.position;

		// Update the rotation and position of the camera
		transform.rotation = rotation;
		transform.position = position;

	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	public static float ClampAngle(float angle, float min, float max) {
		if (angle < -360f) {
			angle += 360f;
		}

		if (angle > 360f) {
			angle -= 360f;
		}
		return Mathf.Clamp (angle, min, max);
	}

}
