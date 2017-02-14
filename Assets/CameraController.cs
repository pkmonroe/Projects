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
		
		float currentAngle = transform.eulerAngles.y;
		float desiredAngle = playerGameObject.transform.eulerAngles.y;
		float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);

		Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
		transform.position = playerGameObject.transform.position - (rotation * offset);

		transform.LookAt(playerGameObject.transform);

	}
}
