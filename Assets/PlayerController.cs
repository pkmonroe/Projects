using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject playerWatcher;

	private float speed = 8000.0f;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		//if (moveVertical > 0) {
			Vector3 movement = playerWatcher.transform.forward * moveVertical;

			playerWatcher.transform.Rotate (new Vector3 (0.0f, moveHorizontal, 0.0f), Space.World);
			playerWatcher.transform.position = transform.position;

			GetComponent<Rigidbody> ().AddForce (movement * speed * Time.deltaTime);
		//}

	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "Cube")
		{
			col.gameObject.transform.parent = this.transform;
		}
	}
		
}
