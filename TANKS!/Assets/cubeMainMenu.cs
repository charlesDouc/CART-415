using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeMainMenu : MonoBehaviour {

	// public variables
	public bool up = true;

	// private variables
	private float m_speed = 0.01f;
	private bool goUp = false;
	private bool goDown = false;

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		// Check the direction of the object
		if (!up) {
			m_speed = -m_speed;
		}

		// Start movement coroutine
		StartCoroutine ("movement");
		
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		Vector3 currentPos = transform.position;

		if (goUp) {
			currentPos.y += m_speed;
		}

		if (goDown) {
			currentPos.y -=m_speed;
		}

		// Update value
		transform.position = currentPos;
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	IEnumerator movement () {
		while (true) {
			goUp = true;
			goDown = false;

			yield return new WaitForSeconds(4);

			goUp = false;
			goDown = true;

			yield return new WaitForSeconds(4);
		}		
	}

}
