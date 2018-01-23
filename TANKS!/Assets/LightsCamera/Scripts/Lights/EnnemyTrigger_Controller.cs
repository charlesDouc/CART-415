using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyTrigger_Controller : MonoBehaviour {

	public GameObject myEnnemyLight;


	// ----------------------------------------
	// Use this for initialization
	// ----------------------------------------
	void Start () {
		
	}

	// ----------------------------------------
	// Update is called once per frame
	// ----------------------------------------
	void Update () {
		
	}

	void OnTriggerEnter() {
		BadLights ennemyScript = myEnnemyLight.GetComponent <BadLights> ();
		ennemyScript.lightUp();
		Destroy (gameObject);
	}
}
