using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class obj_levelMaster : MonoBehaviour {

	// public variables
	public AudioSource m_portalZone;
	public AudioSource m_endZone;
	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.01f;

	// private variables
	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDir = -1;
	private bool musicChange = false;

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		
	}


	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		// Make the cursor invisible and lock it on the center of the screen
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}

		if (Input.GetKeyDown (KeyCode.Backspace)) {
			SceneManager.LoadScene (0);
		}

		if (musicChange) {
			if (m_portalZone.volume > 0f) {
				m_portalZone.volume -= 0.0005f;
			}

			if (m_endZone.volume < 0.3f) {
				m_endZone.volume += 0.0001f;
			}
		}

	}


	// ------------------------------------
	// Methods
	// ------------------------------------
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

	// Fade in/out method
	public void BeginFade (int direction, float speed) {
		fadeSpeed = speed;
		fadeDir = direction;
		SceneManager.LoadScene (0);
	}

	// switch music
	public void changeMusic () {
		musicChange = true;
	}
		
}
