using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTeleporterScript : MonoBehaviour {

	// public variables
	public Transform m_player;
	public Transform m_reciver;

	// private variables
	private bool m_isOverlapping = false;


	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		if (m_isOverlapping) {
			Vector3 portalToPlayer = m_player.position - transform.position;
			float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

			// Check the direction of the player
			if (dotProduct < 0f) {
				Debug.Log ("Working so far");
				// Start teleportation
				float rotationDiff = Quaternion.Angle(transform.rotation, m_reciver.rotation);
				// Flip the roation (enter exit from the other side)
				rotationDiff += 180;
				m_player.Rotate (Vector3.up, rotationDiff);

				Vector3 posOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
				m_player.position = m_reciver.position + posOffset;

				m_isOverlapping = false;

			}
		}
		
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player") {
			m_isOverlapping = true;
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.gameObject.tag == "Player") {
			m_isOverlapping = false;
		}
	}
}
