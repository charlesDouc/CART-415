using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTeleporterScript : MonoBehaviour {

	// public variables
	public Transform m_player;
	public Transform m_reciver;
	public GameObject[] m_portalActivate;
	public GameObject m_currentMainCam;
	public GameObject m_nextMainCam;
	public bool m_changeBG = false;

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

			if (m_portalActivate != null) {
				for (int i = 0; i < m_portalActivate.Length; i++) {
					m_portalActivate[i].SetActive(true);
				}
			}

			if (m_changeBG) {
				m_nextMainCam.SetActive(true);
				m_currentMainCam.SetActive(false);
			}
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.gameObject.tag == "Player") {
			m_isOverlapping = false;
		}
	}
}
