using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMouvement : MonoBehaviour {

	// public variables


	// private variables
	private Vector3[] m_positions;
	private float m_commonHeight = 40f;
	private int m_posIndex = 0;

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {

		// Set all Positions
		m_positions = new Vector3[7];
		m_positions [0] = new Vector3 (0, m_commonHeight, 95f);
		m_positions [1] = new Vector3 (-700, m_commonHeight, 560f);
		m_positions [2] = new Vector3 (800, m_commonHeight, 360f);
		m_positions [3] = new Vector3 (500, m_commonHeight, -180f);
		m_positions [4] = new Vector3 (715, m_commonHeight, -600);
		m_positions [5] = new Vector3 (-500, m_commonHeight, -180f);
		m_positions [6] = new Vector3 (-710, m_commonHeight, -170f);

		// Set inital position
		gameObject.transform.position = m_positions[0];
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			flee ();
		}
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	public void flee () {
		settingDestination (m_posIndex);


	}



	private int settingDestination(int currentIndex) {
		// Get a new index value for the position (while not picking the ending pos)
		int randomIndex = Random.Range (0, m_positions.Length - 1);

		// Make sure the new value dosen't match the current position 
		if (randomIndex == currentIndex) {
			// Get the value into a loop until it finds a valid value
			while (randomIndex == currentIndex) {
				randomIndex = Random.Range (0, m_positions.Length - 1);
			}
		}

		Debug.Log (randomIndex);
		return randomIndex;
	}

}
