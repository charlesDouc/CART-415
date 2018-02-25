using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMouvement : MonoBehaviour {

	// public variables
	public float m_speed;

	// private variables
	private Vector3[] m_positions;
	private float m_commonHeight = 40f;
	private int m_posIndex = 0;
	private bool transit = false;
	private int newIndex;

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
		
		// Set all Positions
		m_positions = new Vector3[7];
		m_positions [0] = new Vector3 (0, m_commonHeight, 95f);
		m_positions [1] = new Vector3 (-700, m_commonHeight, 560f);
		m_positions [2] = new Vector3 (800, m_commonHeight, 360f);
		m_positions [3] = new Vector3 (500, m_commonHeight, -180f);
		m_positions [4] = new Vector3 (715, m_commonHeight, -600);
		m_positions [5] = new Vector3 (-500, m_commonHeight, -180f);
		m_positions [6] = new Vector3 (-710, m_commonHeight, -170f);
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			transit = true;
			newIndex = settingDestination (m_posIndex);
		}

		if (transit) {
			flee (newIndex);
		}
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	public void flee (int nextPos) {
		Debug.Log ("working?");

		if (m_commonHeight < 350f) {
			m_commonHeight += 5f;
		} else {
			float step = m_speed * Time.deltaTime;
			gameObject.transform.position = Vector3.MoveTowards (transform.position, m_positions[m_posIndex], step);
		}
	}



	private int settingDestination(int currentIndex) {
		// Get a new index value for the position (while not picking the ending pos)
		int randomIndex = Random.Range (0, m_positions.Length - 1);

		// Make sure the new value dosen't match the current position 
		if (randomIndex == currentIndex) {
			bool redoRandom = true;
			// Get the value into a loop until it finds a valid value
			while (redoRandom) {
				randomIndex = Random.Range (0, m_positions.Length - 1);

				if (randomIndex != currentIndex) {
					redoRandom = false;
				} else {
					redoRandom = true;
				}
			}
		}
		// return the correct index
		Debug.Log ("Entity's next location: " + randomIndex);
		return randomIndex;
	}

}
