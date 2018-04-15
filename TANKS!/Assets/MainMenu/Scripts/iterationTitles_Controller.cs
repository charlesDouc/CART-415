using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iterationTitles_Controller : MonoBehaviour {

	// public variables
	public float m_fadeSpeed = 0.05f;			// Fade animation speed

	// private variables
	private CanvasGroup m_canvas;				// Canvas group
	private bool m_fadeIn = false;				// Fade in bool animation
	private bool m_fadeOut = false;				// Fade out bool animation
	private float m_opacity;					// Alpha value 

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		// Get the canvas group component
		m_canvas = gameObject.GetComponent<CanvasGroup>();
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		// Fade in animation 
		if (m_fadeIn) {
			// Get the current alpha value
			m_opacity = m_canvas.alpha;

			// Get fade up
			if (m_opacity < 1f) {
				m_opacity += m_fadeSpeed;
			} else {
				// Stop the animation
				m_fadeIn = false;
			}

			// Update the value
			m_canvas.alpha = m_opacity;
		}


		// Fade out animation 
		if (m_fadeOut) {
			// Get the current alpha value
			m_opacity = m_canvas.alpha;

			// Get fade down
			if (m_opacity > 0f) {
				m_opacity -= m_fadeSpeed;
			} else {
				// Stop the animation
				m_fadeOut = false;
			}

			// Update the value
			m_canvas.alpha = m_opacity;
		}
		
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	public void fadeIn() {
		// Start the fade in animation
		m_fadeIn = true;
	}

	public void fadeOut() {
		// Start the fade in animation
		m_fadeOut = true;
	}

}
