using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private GameObject playerGameObject;
	private Vector3 originalPosition;
	private Quaternion originalRotation;

	private Vector3 offset;

	void Start() {
		originalPosition = transform.position;
		originalRotation = transform.rotation;
	}
	// Use this for initialization
	public void TargetPlayerObject( GameObject player) {
		transform.position = originalPosition;
		transform.rotation = originalRotation;

		playerGameObject = player;
		offset = playerGameObject.transform.position - transform.position;
	}

	// Update is called once per frame
	void LateUpdate() {
		if (playerGameObject != null) {
			float desiredAngle = playerGameObject.transform.eulerAngles.y;
			Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
			transform.position = playerGameObject.transform.position - (rotation * offset);
			transform.LookAt(playerGameObject.transform);
		}
	}
}
