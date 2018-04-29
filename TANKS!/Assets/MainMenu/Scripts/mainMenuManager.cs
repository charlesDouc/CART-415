using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour {

	// public variables
	public int openMenu = 0;

	// private variables
	private static mainMenuManager m_instance;

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Awake () {
		//if we don't have an [m_instance] set yet
         if(!m_instance) {
             m_instance = this ;
         }
         //otherwise, if we do, kill this thing
         else {
             Destroy(this.gameObject) ;
         }
 		 
 		 // Don't destroy this object on load
         DontDestroyOnLoad(this.gameObject);
	}

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

	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	public void changeScene (int index) {
		// Remember the index
		openMenu = index;
		// Load scene
		SceneManager.LoadScene(index);
	}

	



}
