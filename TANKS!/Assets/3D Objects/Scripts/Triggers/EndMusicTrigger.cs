using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMusicTrigger : MonoBehaviour {

	// public variables
	public GameObject m_gameMaster;

	// private variables
	private bool m_changeMusic = false;
	private bool m_oneTime = true;

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {

		if (m_changeMusic) {
			obj_levelMaster gmScript = m_gameMaster.GetComponent<obj_levelMaster> ();
			gmScript.changeMusic ();

			m_changeMusic = false;
		}
		
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player" && m_oneTime) {
			m_changeMusic = true;
			m_oneTime = false;
		}
	}

}
