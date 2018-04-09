using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterCollision : MonoBehaviour {

	// public variables
	public GameObject m_thePlayer;
	public Vector3 m_resetPos;
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
	void OnTriggerEnter (Collider collision) {
		if (collision.gameObject.tag == "Player") {
			// Debug.Log ("work");
			TankMovementSound m_playerScript = m_thePlayer.GetComponent<TankMovementSound> ();
			m_playerScript.resettingPlayer (m_resetPos);
		}
	}

}
