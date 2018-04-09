using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointController : MonoBehaviour {

	//public variables
	public GameObject m_entity;
	public GameObject m_tank;
	public int m_index;
	public bool silencePlayer;

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
	void OnTriggerEnter(Collider collision) {
		if (collision.gameObject.tag == "Player") {
			EntityNotes_end entityScript = m_entity.GetComponent<EntityNotes_end>();
			TankNotes tankScript = m_tank.GetComponent<TankNotes>();

			entityScript.speakAtCheckpoint(m_index);
			tankScript.turnVolumeDown(silencePlayer);


			Destroy(gameObject);
		}
	}
}
