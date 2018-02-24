using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankNotes : MonoBehaviour {

	// public variables
	public AudioSource m_audio;
	public GameObject theEnity;
	public AudioClip[] m_notes;

	// private variables
	private int m_sequenceIndex = 0;
	private int[] m_recordingNote;
	private bool startDialogue;

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		// Initiate the array
		m_recordingNote = new int[6];

		// Don't start the conversation yet
		startDialogue = false;
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {

		// If user press down 1 on the number row ----------
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			// Play a note
			m_audio.clip = m_notes [0];
			m_audio.Play ();

			// Record the note in a sequence if the entity is listening
			recordSequence(1);
			// Add a value to the sequence index
			m_sequenceIndex ++;

		}

		// If user press down 2 on the number row ----------
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			// Play a note
			m_audio.clip = m_notes [1];
			m_audio.Play ();

			// Record the note in a sequence if the entity is listening
			recordSequence(2);
			// Add a value to the sequence index
			m_sequenceIndex ++;
		}

		// If user press down 3 on the number row ----------
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			// Play a note
			m_audio.clip = m_notes [2];
			m_audio.Play ();

			// Record the note in a sequence if the entity is listening
			recordSequence(3);
			// Add a value to the sequence index
			m_sequenceIndex ++;
		}

		// If user press down 4 on the number row ----------
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			// Play a note
			m_audio.clip = m_notes [3];
			m_audio.Play ();

			// Record the note in a sequence if the entity is listening
			recordSequence(4);
			// Add a value to the sequence index
			m_sequenceIndex ++;
		}

		// If user press down 5 on the number row ----------
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			// Play a note
			m_audio.clip = m_notes [4];
			m_audio.Play ();

			// Record the note in a sequence if the entity is listening
			recordSequence(5);
			// Add a value to the sequence index
			m_sequenceIndex ++;
		}

		// If user press down 6 on the number row ----------
		if (Input.GetKeyDown (KeyCode.Alpha6)) {
			// Play a note
			m_audio.clip = m_notes [5];
			m_audio.Play ();

			// Record the note in a sequence if the entity is listening
			recordSequence(6);
			// Add a value to the sequence index
			m_sequenceIndex ++;
		}

		// If user press down 7 on the number row ----------
		if (Input.GetKeyDown (KeyCode.Alpha7)) {
			// Play a note
			m_audio.clip = m_notes [6];
			m_audio.Play ();

			// Record the note in a sequence if the entity is listening
			recordSequence(7);
			// Add a value to the sequence index
			m_sequenceIndex ++;
		}

		// If user press down 8 on the number row ----------
		if (Input.GetKeyDown (KeyCode.Alpha8)) {
			// Play a note
			m_audio.clip = m_notes [7];
			m_audio.Play ();

			// Record the note in a sequence if the entity is listening
			recordSequence(8);
			// Add a value to the sequence index
			m_sequenceIndex ++;
		}
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	public void startTalking () {
		// Start the dialogue and reset the sequencer
		startDialogue = true;
		m_sequenceIndex = 0;			
		Debug.Log ("Entity is listenning");
	}



	public void recordSequence (int notePlayed) {
		// Record a value for each note on the sequence
		if (m_sequenceIndex < m_recordingNote.Length && startDialogue) {
			m_recordingNote [m_sequenceIndex] = notePlayed;
		}

		// When the sequence is finished
		if (m_sequenceIndex == m_recordingNote.Length - 1 && startDialogue) {
			// Print the sequence in the console;
			Debug.Log ("Player Sequence : " + m_recordingNote [0] + m_recordingNote [1]
				+ m_recordingNote [2] + m_recordingNote [3]
				+ m_recordingNote [4] + m_recordingNote [5]);

			// Translate data to the entity
			EntityNotes notesScript = theEnity.GetComponent<EntityNotes>();
			notesScript.listen (m_recordingNote);

			// End the dialogue
			startDialogue = false;
		}
	}

}
