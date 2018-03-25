using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTextureSetup : MonoBehaviour {

	// public variables
	public Camera m_cameraA;
	public Camera m_cameraB;
	public Material m_cameraMatA;
	public Material m_cameraMatB;


	// private variables

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		if (m_cameraB.targetTexture != null) {
			m_cameraB.targetTexture.Release ();
		}
		m_cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		m_cameraMatB.mainTexture = m_cameraB.targetTexture;


		if (m_cameraA.targetTexture != null) {
			m_cameraA.targetTexture.Release ();
		}
		m_cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		m_cameraMatA.mainTexture = m_cameraA.targetTexture;
		
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
