using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityNotes : MonoBehaviour {

	// public variables
	public Collider m_Trigger;
	public GameObject m_Player;
	[Header("Answers")]
	public AudioClip[] m_randomNotes;
	public AudioClip m_endNotes;

	// private variables
	private AudioSource m_audio;
	private int[] m_playerSequence;
	private int[] m_endSequence;

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		m_audio = GetComponent<AudioSource> ();

		// Set the arrays
		m_playerSequence = new int[6];
		// Set the premade answers
		m_endSequence = new int[] {1, 3, 5, 6, 2, 1}; 
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	void OnTriggerEnter (Collider target) {
		// Check if the player is entering the trigger of the entity
		if (target.gameObject.tag == "Player") {
			// Start the dialogue with the player
			TankNotes playerScript = m_Player.GetComponent<TankNotes>();
			playerScript.startTalking ();
			// Disable the trigger
			m_Trigger.enabled = false;
		}
	}





	public void listen(int[] receiving) {
		// Receive seuqence from the player
		m_playerSequence = receiving;
		// Start the a couritine to know what to answer
		StartCoroutine(answer());

		 // Print the dialogue
		 Debug.Log ("Entity just received this sequence : " 
		 + m_playerSequence[0] + m_playerSequence[1] + m_playerSequence[2]											   
		 + m_playerSequence[3] + m_playerSequence[4] + m_playerSequence[5]);
		
	}
		



	IEnumerator answer () {
		// Check if any sequence is linked to a premade one
		if (analyse(m_endSequence)) {					// The end scene
			// Wait a bit before answering
			yield return new WaitForSeconds (2);
			m_audio.clip = m_endNotes;
			m_audio.Play ();
			// Print what the entity is answering
			Debug.Log ("Playing Ending");

		} else {										// If no premade were found. Random noises.
			// Wait a bit before answering
			yield return new WaitForSeconds (2);
			// Get a random number and play the notes linked to the index
			int randomIndex = Random.Range (0, m_randomNotes.Length);
			m_audio.clip = m_randomNotes [randomIndex];
			m_audio.Play ();
			// Print what the entity is answering
			Debug.Log ("Playing a random sequence ( " + randomIndex + " )");
		}
	}





	bool analyse (int[] premade) {
		// create a bool and set it true
		bool same = true;
		// Compare the player sequence with any premade
		for (int i = 0; i < m_playerSequence.Length; i++) {
			// If at one point a value are not the same, change the bool to false
			if (m_playerSequence [i] != premade [i]) {
				same = false;
			}
		}
		// Return the result of the analyse
		return same;
	}



}
