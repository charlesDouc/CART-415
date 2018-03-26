using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLevel : MonoBehaviour {

	// public variables
	public Light m_monolithLight;
	public GameObject m_gameMaster;

	// private variables
	private bool m_startEnding = false;

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		

		if (m_startEnding) {
			float step = 2f * Time.deltaTime;
			// Start increasing the sun intensity
			if (m_monolithLight.intensity < 100) {
				m_monolithLight.intensity += step;
			} 
				


		}
		
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player") {
			m_startEnding = true;
		}
	}

}
