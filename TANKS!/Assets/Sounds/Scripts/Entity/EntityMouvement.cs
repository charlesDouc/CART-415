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
	private bool landing = false;

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
		m_positions [5] = new Vector3 (-695f, m_commonHeight, -150f);
		m_positions [6] = new Vector3 (-690f, m_commonHeight, -700f);

		// Set inital position
		gameObject.transform.position = m_positions[0];
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		// Update all positions (for the height)
		m_positions = new Vector3[7];
		m_positions [0] = new Vector3 (0, m_commonHeight, 95f);
		m_positions [1] = new Vector3 (-700, m_commonHeight, 560f);
		m_positions [2] = new Vector3 (800, m_commonHeight, 360f);
		m_positions [3] = new Vector3 (500, m_commonHeight, -180f);
		m_positions [4] = new Vector3 (715, m_commonHeight, -600);
		m_positions [5] = new Vector3 (-695f, m_commonHeight, -150f);
		m_positions [6] = new Vector3 (-690f, m_commonHeight, -700f);

		// If the function start moving is activated
		if (transit) {
			flee (newIndex);
		}
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	private void flee (int nextPos) {
		// Get the value of current position
		Vector3 currentPos = transform.position;

		// Variable to calculate a speed for mouvement
		float step = m_speed * Time.deltaTime;

		// Trow the object in the air first
		if (m_commonHeight < 205f	&& 	!landing) {
			m_commonHeight += step;
			gameObject.transform.position = Vector3.MoveTowards (transform.position, m_positions [m_posIndex], step);
		// Once the object is in the air, move it to the next destination
		} else if (currentPos.x != m_positions [newIndex].x) {
			gameObject.transform.position = Vector3.MoveTowards (transform.position, m_positions [newIndex], step);
		// Once at new position start the landing of the object
		} else {
			landing = true;
		}

		// Land the object to the new location 
		if (m_commonHeight > 40f	&& 	landing) {
			m_commonHeight -= step;
			gameObject.transform.position = Vector3.MoveTowards (transform.position, m_positions [newIndex], step);
		// Once it arrived, disable the flee function, and reset the listen method
		} else if (landing) {
			Debug.Log ("ARRIVED");
			// Change the value of the current index
			m_posIndex = newIndex;
			landing = false;
			transit = false;

			// Reset the listen state of the entity 
			EntityNotes notesScript = gameObject.GetComponent<EntityNotes> ();
			notesScript.resetListenState ();
		}
	}




	public void startMoving () {
		// Start the flee function in Update
		transit = true;
		// Set the new destination
		newIndex = settingDestination (m_posIndex);
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
