using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLightMainMenu : MonoBehaviour {

	// public variables
	public GameObject theTotch;

	// private variables

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		StartCoroutine("blink");
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	IEnumerator blink() {
		while (true) {
			theTotch.SetActive (true);
			yield return new WaitForSeconds(0.1f);
			theTotch.SetActive (false);
			yield return new WaitForSeconds(0.1f);
			theTotch.SetActive (true);
			yield return new WaitForSeconds(0.1f);
			theTotch.SetActive (false);
			yield return new WaitForSeconds(0.1f);
			theTotch.SetActive (true);
			yield return new WaitForSeconds(4f);
			theTotch.SetActive (false);
			yield return new WaitForSeconds(0.1f);
			theTotch.SetActive (true);
			yield return new WaitForSeconds(0.1f);
			theTotch.SetActive (false);
			yield return new WaitForSeconds(0.1f);
			theTotch.SetActive (true);
			yield return new WaitForSeconds(4f);
		}
	}

}
