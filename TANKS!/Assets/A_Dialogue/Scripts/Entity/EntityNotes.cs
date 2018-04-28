using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityNotes : MonoBehaviour {

	// public variables
	public AudioSource m_audio;
	public Collider m_Trigger;
	public Collider m_endTrigger;
	public GameObject m_Player;
	public GameObject m_theGM;
	[Header("Answers")]
	public AudioClip[] m_randomNotes;
	public AudioClip[] m_premadeNotes;
	public AudioClip m_entityListen;
	public AudioClip m_endNotes;
	public AudioClip m_lastSequenceNotes;
	// private variables
	private int[] m_playerSequence;
	private int[] m_endSequence;
	private int[] m_clairLuneSequence;
	private int[] m_zeldaSequence;
	private int[] m_whentSaintsSequence;
	private int[] m_happyBirthdaySequence;
	private int[] m_starWarsSequence;
	private int[] m_marioSequence;
	private bool m_theEnd;

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		m_audio = GetComponent<AudioSource> ();

		// Desactivate end trigeer
		m_endTrigger.enabled = false;
		m_theEnd = false;
		// Set the arrays
		m_playerSequence = new int[6];
		// Set the premade answers
		m_endSequence = new int[] {7, 8, 6, 4, 3, 1}; 
		m_clairLuneSequence = new int[] {5, 5, 5, 6, 7, 6};		// clair de la lune
		m_zeldaSequence = new int[] {4, 6, 7, 4, 6, 7};			// zelda sariah's song
		m_whentSaintsSequence = new int[] {1, 3, 4, 5, 1, 3};	// Oh when the Saints
		m_happyBirthdaySequence = new int[] {1, 1, 2, 1, 4, 3}; // Happy birthday
		m_starWarsSequence = new int[] {6, 6, 6, 4, 8, 6};		// Star Wars
		m_marioSequence = new int[] {6, 6, 6, 4, 6, 8};			// Super Mario 
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
		if (target.gameObject.tag == "Player"	&& !m_theEnd) {
			// Start the dialogue with the player
			TankNotes playerScript = m_Player.GetComponent<TankNotes>();
			playerScript.startTalking ();
			// Disable the trigger
			m_Trigger.enabled = false;
			// Give feedback to the player that its listening
			m_audio.clip = m_entityListen;
			m_audio.Play();
		// If it's the end
		} else if (m_theEnd) {
			// Play last sequence
			StartCoroutine(lastSequence());
		}
	}



	public void resetListenState () {
		// Reset the collider so the player can interact again with the player
		m_Trigger.enabled = true;
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
			// Start fleeing to the end location on the map after some time
			yield return new WaitForSeconds (6);
			EntityMouvement mouvementScript = gameObject.GetComponent<EntityMouvement> ();
			mouvementScript.goToEnd ();
		
		// ------ PREMADES ----------
		} else if (analyse(m_clairLuneSequence)) {
			// Start au clair de la lune
			yield return new WaitForSeconds (1);
			playPremade(0);
			yield return new WaitForSeconds (6);
			resetListenState();
		
		} else if (analyse(m_zeldaSequence)) {
			// Start zelda
			yield return new WaitForSeconds (1);
			playPremade(1);
			yield return new WaitForSeconds (10);
			resetListenState();
		
		} else if (analyse(m_whentSaintsSequence)) {
			// Start when the saints
			yield return new WaitForSeconds (1);
			playPremade(2);
			yield return new WaitForSeconds (10);
			resetListenState();
		
		} else if (analyse(m_happyBirthdaySequence)) {
			// Start happy birthday
			yield return new WaitForSeconds (1);
			playPremade(3);
			yield return new WaitForSeconds (6);
			resetListenState();

		} else if (analyse(m_starWarsSequence)) {
			// Start star wars
			yield return new WaitForSeconds (1);
			playPremade(4);
			yield return new WaitForSeconds (10);
			resetListenState();

		} else if (analyse(m_marioSequence)) {
			// Start mario
			yield return new WaitForSeconds (1);
			playPremade(5);
			yield return new WaitForSeconds (6);
			resetListenState();



		// If no premade were found. Random noises.
		} else  {
			// Wait a bit before answering
			yield return new WaitForSeconds (2);
			// Get a random number and play the notes linked to the index
			int randomIndex = Random.Range (0, m_randomNotes.Length);
			m_audio.clip = m_randomNotes [randomIndex];
			m_audio.Play ();
			// Print what the entity is answering
			Debug.Log ("Playing a random sequence ( " + randomIndex + " )");

			// Start fleeing to a new location on the map after some time
			yield return new WaitForSeconds (6);
			EntityMouvement mouvementScript = gameObject.GetComponent<EntityMouvement> ();
			mouvementScript.startMoving ();
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




	public void startEnding() {
		// Open the trigger for the end sequence
		m_theEnd = true;
		m_endTrigger.enabled = true;
	}



	IEnumerator lastSequence() {
		m_audio.clip = m_lastSequenceNotes;
		m_audio.Play();
		yield return new WaitForSeconds(25);
		DialogueLevelMaster theGMScript = m_theGM.GetComponent<DialogueLevelMaster>();
		theGMScript.BeginFade(1);
		yield return new WaitForSeconds(3);
		theGMScript.loadScene(4);
	}



	void playPremade (int premadeIndex) {
		m_audio.clip = m_premadeNotes[premadeIndex];
		m_audio.Play();
	}



}
