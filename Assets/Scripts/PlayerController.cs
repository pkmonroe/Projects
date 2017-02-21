using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject playerWatcher;

	private float speed = 8000.0f;
	public float rotationSpeed = 2;

	private Rigidbody rb;

	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	public void SetGameManager (GameManager _manager) {
		gameManager = _manager;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = playerWatcher.transform.forward * moveVertical;
		float rotation = moveHorizontal * rotationSpeed;

		playerWatcher.transform.Rotate (new Vector3 (0.0f, rotation, 0.0f), Space.World);
		playerWatcher.transform.position = transform.position;

		rb.AddForce (movement * speed * Time.deltaTime);

	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Debris")
		{
			//find the colloision point.
			ContactPoint cp = collision.contacts[0];

			Debris debris = collision.gameObject.GetComponent<Debris> ();
			debris.AttachToPlayer (cp.point, transform);

			gameManager.CollectDebris ();
		}
	}
		
}
