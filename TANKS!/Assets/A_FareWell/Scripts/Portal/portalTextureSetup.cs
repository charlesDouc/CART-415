using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTextureSetup : MonoBehaviour {

	// public variables
	public Camera[] m_cameras;
	public Material[] m_cameraMats;


	// private variables

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {

		// Loop to set up all portal's cameras
		for (int i = 0; i < m_cameras.Length; i ++) {
			if (m_cameras[i].targetTexture != null) {
				m_cameras[i].targetTexture.Release ();
			}

			m_cameras[i].targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
			m_cameraMats[i].mainTexture = m_cameras[i].targetTexture;
			
		}
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		
	}

	// ------------------------------------
	// Methods
	// ------------------------------------

}
