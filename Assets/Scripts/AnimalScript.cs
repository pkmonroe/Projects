using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalScript : MonoBehaviour {

	public GameObject playerGameObject;

	// Update is called once per frame
	void FixedUpdate () {
		if (playerGameObject != null) {
			transform.LookAt (playerGameObject.transform);
		} else {
			playerGameObject = Object.FindObjectOfType<PlayerController> ().playerWatcher;		
		}
	}
}
