using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityNotes_end : MonoBehaviour {

	// public variables
	public AudioSource m_audio;
	public AudioSource m_audioSecondChannel;
	public Collider m_Trigger;
	public GameObject m_Player;
	public GameObject m_theGM;
	[Header("Answers")]
	public AudioClip m_endNotes;
	public AudioClip m_noNotes;
	public AudioClip m_lastWord;
	public AudioClip[] m_payRespect;

	// private variables
	private int[] m_playerSequence;
	private int[] m_endSequence;
	private bool entityListen = true;

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		m_audio = GetComponent<AudioSource> ();


		// Set the arrays
		m_playerSequence = new int[6];
		// Set the premade answers
		m_endSequence = new int[] {7, 8, 6, 4, 3, 1}; 
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {

		if (entityListen) {
			// Start the dialogue with the player
			TankNotes playerScript = m_Player.GetComponent<TankNotes>();
			playerScript.startTalking ();

			// Desactivate 
			entityListen = !entityListen;
		} 

		
	}


	// ------------------------------------
	// Methods
	// ------------------------------------
	void OnTriggerEnter (Collider target) {
		// Check if the player is entering the trigger of the entity
		if (target.gameObject.tag == "Player") {

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
		if (analyse(m_endSequence)) {					// The end sequene
			// Wait a bit before answering
			yield return new WaitForSeconds (2);
			m_audio.clip = m_endNotes;
			m_audio.Play ();
			// Print what the entity is answering
			Debug.Log ("Playing Ending sequence");
			entityListen = true;

		} else {										// If no premade were found. No noise.
			// Wait a bit before answering
			yield return new WaitForSeconds (2);
			m_audio.clip = m_noNotes;
			m_audio.Play ();
			// Print what the entity is answering
			Debug.Log ("Playing a no sequence");
			entityListen = true;
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


	public IEnumerator theEnd() {
		m_audio.clip = m_lastWord;
		m_audio.Play();
		DialogueLevelMaster theGMScript = m_theGM.GetComponent<DialogueLevelMaster>();
		theGMScript.noMusic();
		yield return new WaitForSeconds(27);
		theGMScript.BeginFade(1);
		yield return new WaitForSeconds(5);
		theGMScript.loadScene(0);
	}



	public void speakAtCheckpoint(int index) {
		m_audioSecondChannel.clip = m_payRespect[index];
		m_audioSecondChannel.Play();
	}

}
