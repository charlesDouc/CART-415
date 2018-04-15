using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMainMenu_Controller : MonoBehaviour {

	// public variables
	public Transform[] m_targetPositions;			// Array of all target position for the camera
	public GameObject[] m_gameTitles;				// Array of all target position for the camera
	public float m_smoothTime = 0.3f;				// Ease time
	public bool blockInput = true;
	[Space(20)]
	public Texture2D fadeOutTexture;				// Fade texture
	public float fadeSpeed = 0.01f;					// Fade texture speed
	public AudioSource m_audio;						// The audio source used fo SFX select

	// private variables
	private bool m_allowRight = false;				// Determine if the camera can go right
	private bool m_allowLeft = false;				// Determine if the camera can go left
	private int m_currentTarget;					// Index for current position
	private bool m_isMoving = false;				// Bool to catch the state of movement
	private Vector3 m_velocity = Vector3.zero;		// For smooth animation
	private int fadeDir = -1;						// For opening and closing fade
	private float alpha = 1.0f;						// Alpha for opewning and closing fade
	private int drawDepth = -1000;
	private mainMenuManager theMainMenuScript;		// MainMenuScript active
	private bool m_canLoad = false;					// Bool to determine if the player can load a game

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		// Get the main menu manager script
		theMainMenuScript = GameObject.FindGameObjectWithTag("MainMenuManager").GetComponent<mainMenuManager>();

		// Set the first position
		m_currentTarget = theMainMenuScript.openMenu;
		gameObject.transform.position = m_targetPositions[m_currentTarget].position;

		// MAke appear the first title
		iterationTitles_Controller beginTitle = m_gameTitles[m_currentTarget].GetComponent<iterationTitles_Controller>();
		beginTitle.fadeIn();

		// Open the menu
		StartCoroutine("openMenu");
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		// Check directions pssible
		checkAllow ();

		// Title screen input
		if (m_currentTarget == 0 && Input.GetKeyDown(KeyCode.Return) && !blockInput) {
			// Start fade animation
			StartCoroutine("fadeAnimation");

			// Get the new target pos
			m_currentTarget ++;
			
			// Start movement
			m_isMoving = true; 
		}

		// If the user press right input and can go right
		if (Input.GetKeyDown(KeyCode.RightArrow) && m_allowRight && !m_isMoving && !blockInput  ||
			Input.GetKeyDown(KeyCode.D)	&& m_allowRight && !m_isMoving	&& !blockInput) {
				// Start fade animation
				StartCoroutine("fadeAnimation");

				// Get the new target pos
				m_currentTarget ++;

				// Start movement
				m_isMoving = true; 
		}


		// If the user press right input and can go left
		if (Input.GetKeyDown(KeyCode.LeftArrow) && m_allowLeft && !m_isMoving && !blockInput  ||
			Input.GetKeyDown(KeyCode.A)	&& m_allowLeft && !m_isMoving && !blockInput) {
				// Start fade animation
				StartCoroutine("fadeAnimation");

				// Get the new target pos
				m_currentTarget --;

				// Start movement
				m_isMoving = true; 
		}

		// Animation sequence to go from a pos to another
		if (m_isMoving) {
			// Start the movement animation with a easing effect
			transform.position = Vector3.SmoothDamp(transform.position, m_targetPositions[m_currentTarget].position, ref m_velocity, m_smoothTime);
		}

		// If user press space on a game
		if (Input.GetKeyDown(KeyCode.Space) && m_canLoad) {
			// Close the menu
			StartCoroutine("closeMenu");
			m_allowLeft = false;
			m_allowRight = false;
			m_canLoad = false;

			// MAke a sound
			m_audio.Play();
		}
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	private void checkAllow () {
		// check where you can go
		if (m_currentTarget == 0) {
			m_allowRight = false;
			m_allowLeft = false;
			m_canLoad = false;
		}

		if (m_currentTarget == 1) {
			m_allowRight = true;
			m_allowLeft = false;
			m_canLoad = true;
		}

		if (m_currentTarget == 2) {
			m_allowRight = true;
			m_allowLeft = true;
			m_canLoad = true;
		}

		if (m_currentTarget == 3) {
			m_allowRight = true;
			m_allowLeft = true;
			m_canLoad = true;
		}

		if (m_currentTarget == 4) {
			m_allowRight = false;
			m_allowLeft = true;
			m_canLoad = false;
		}
	}

	IEnumerator fadeAnimation () {
		// Fade out animation
		iterationTitles_Controller oldTitleScript = m_gameTitles[m_currentTarget].GetComponent<iterationTitles_Controller>();
		oldTitleScript.fadeOut();

		yield return new WaitForSeconds(1f);

		// Fade in animation
		iterationTitles_Controller newTitleScript = m_gameTitles[m_currentTarget].GetComponent<iterationTitles_Controller>();
		newTitleScript.fadeIn();

		yield return new WaitForSeconds(0.5f);

		// Movement is finished
		m_isMoving = false;
	}




	// Fade in/out effect
	void OnGUI () {
		//fade out/in the alpha value
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		// force clamp the number between 0 and 1
		alpha = Mathf.Clamp01 (alpha);

		// set the color of our GUI
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
	}

	// Fade in/out on screen method
	public void BeginFade (int direction) {
		fadeDir = direction;
	}



	IEnumerator openMenu() {
		yield return new WaitForSeconds(1f);
		blockInput = false;
	}

	IEnumerator closeMenu() {
		BeginFade(1);
		yield return new WaitForSeconds(4);
		theMainMenuScript.changeScene(m_currentTarget);
	}

}
