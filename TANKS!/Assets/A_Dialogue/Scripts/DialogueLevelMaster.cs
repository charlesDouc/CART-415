using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueLevelMaster : MonoBehaviour {

	// public variables
	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.01f;
	public AudioSource m_music;
	public GameObject pauseMenu;

	//private variables
	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDir = -1;
	private float musicVolume = 1.0f;
	private bool fadeMusic = false;
	private bool pause = false;


	// --------------------------------------
	// Use this for initialization
	// --------------------------------------
	void Start () {
		// Set the cursor invisible
		Cursor.visible = false;
	}

	// --------------------------------------
	// Update is called once per frame
	// --------------------------------------
	void Update () {
		Cursor.lockState = CursorLockMode.Locked;
		
		if (fadeMusic && musicVolume > 0) {
			// silence slowly the music
			musicVolume -= 0.01f;
			m_music.volume = musicVolume;
		}

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

	// --------------------------------------
	// Methods
	// --------------------------------------
	// Load a scene
	public void loadScene (int index) {
		SceneManager.LoadScene (index);
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

	// Fade in/out method
	public void BeginFade (int direction) {
		fadeDir = direction;
	}


	public void noMusic () {
		fadeMusic = true;
	}

	IEnumerator returnMainMenu () {
		yield return new WaitForSeconds(0.5f);
		loadScene(0);
	}
}
