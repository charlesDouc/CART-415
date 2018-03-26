using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextSceneTrigger : MonoBehaviour {

	// public variables
	public GameObject m_gameMaster;

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
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player") {
			
			obj_levelMaster gmScript = m_gameMaster.GetComponent<obj_levelMaster> ();
			gmScript.BeginFade (1, 100f);
		}
	}

}
