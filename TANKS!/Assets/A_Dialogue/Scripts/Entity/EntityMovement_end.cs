using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement_end : MonoBehaviour {

	// public variables
	public float m_speed;
	public Vector3 m_finalPositions;

	// private variables
	private bool finalEnd = false;

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		finalEnd = false;
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		Vector3 currentPos = transform.position;
		// Move slowy toward the final
		float step = m_speed * Time.deltaTime;


		gameObject.transform.position = Vector3.MoveTowards (transform.position, m_finalPositions, step);


		if (currentPos.z == m_finalPositions.z	&& !finalEnd) {
			Debug.Log("THATS IT");
			finalEnd = true;
			EntityNotes_end theEntityScript = gameObject.GetComponent<EntityNotes_end>();
			StartCoroutine(theEntityScript.theEnd());
		}
	}

	// ------------------------------------
	// Methods
	// ------------------------------------

}
