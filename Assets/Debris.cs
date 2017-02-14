using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour {

	private Vector3 attachPoint = new Vector3 (0, 0.5f, 0);

	public bool AttachToPlayer(Vector3 cp, Transform parent) {
		transform.localPosition = cp;
		transform.parent = parent;

		transform.rotation = Quaternion.identity;

		GetComponent<BoxCollider> ().enabled = false;

		return true;
	}
}
