using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject playerWatcher;

	private Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		
		float moveHorizontal = Input.GetAxis(GameConstants.HORIZONTAL_AXIS);
		float moveVertical = Input.GetAxis(GameConstants.VERTICAL_AXIS);

		Vector3 movement = playerWatcher.transform.forward * moveVertical;
		float rotation = moveHorizontal * GameConstants.PLAYER_ROTATION_SPEED;

		playerWatcher.transform.Rotate(new Vector3 (0.0f, rotation, 0.0f), Space.World);
		playerWatcher.transform.position = transform.position;

		rb.AddForce(movement * GameConstants.PLAYER_SPEED * Time.deltaTime);

	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == GameConstants.DEBRIS_TAG) {
			//find the collision point.
			ContactPoint cp = collision.contacts [0];

			Debris debris = collision.gameObject.GetComponent<Debris>();
			debris.Collect(cp.point, transform);
		}
	}
		
}
