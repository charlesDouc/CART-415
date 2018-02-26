using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seeObjectController : MonoBehaviour {

	// private variables
	private AudioSource m_audio;
	private bool firstTime = true;

	// --------------------------------------
	// Use this for initialization
	// --------------------------------------
	void Start () {
		m_audio = GetComponent<AudioSource>();
	}


	// --------------------------------------
	// Methods
	// --------------------------------------
	void OnTriggerEnter(Collider collision) {
		if (collision.gameObject.tag == "Player" && firstTime) {
			m_audio.Play();
			firstTime = !firstTime;
		}
	}
}
