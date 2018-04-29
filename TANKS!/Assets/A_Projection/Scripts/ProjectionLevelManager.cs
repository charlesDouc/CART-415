using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectionLevelManager : MonoBehaviour {

	//public variables
	public GameObject[] zones;
	public GameObject pauseMenu;

	private bool pause = false;

	// ---------------------------------------
	// Use this for initialization
	// ---------------------------------------
	void Start () {
		// Disabled all zones
		for (int i = 0; i < zones.Length; i++) {
			zones[i].SetActive(false);
			Debug.Log ("Zone " + i + " disabled!");
		}

		pauseMenu.SetActive(false);

		// Set the first and second zone active
		zones[0].SetActive(true);
		zones[1].SetActive(true);
	}


	// ---------------------------------------
	// Update is called once per frame
	// ---------------------------------------
	void Update () {

		// Set the ESC key to quit the application
		if (Input.GetKeyDown (KeyCode.Escape)) {
			pause = !pause;
		}

		if (pause) {
			Time.timeScale = 0.0f;
			pauseMenu.SetActive(true);

		} else {
			Time.timeScale = 1.0f;
			pauseMenu.SetActive(false);
		}

		if (Input.GetKeyDown (KeyCode.Return) && pause) {
			StartCoroutine("returnMainMenu");
			pause = !pause;
		}
	}


	// ---------------------------------------
	// Methods
	// ---------------------------------------
	public void reload () {
		// Reload the game (scene)
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void load (int index) {
		// Load a scene (scene)
		SceneManager.LoadScene(index);
	}

	IEnumerator returnMainMenu () {
		yield return new WaitForSeconds(0.5f);
		load(0);
	}
}
