using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject playerGameObject;

	private Vector3 offset;
	public float damping = 1f;

	// Use this for initialization
	void Start () {
		offset = playerGameObject.transform.position -transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		float desiredAngle = playerGameObject.transform.eulerAngles.y;

		Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
		transform.position = playerGameObject.transform.position - (rotation * offset);

		transform.LookAt(playerGameObject.transform);

	}
}
