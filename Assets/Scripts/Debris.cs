using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour {

	public bool AttachToPlayer(Vector3 cp, Transform parent) {
		transform.localPosition = cp;
		transform.parent = parent;

		transform.rotation = Quaternion.identity;

		GetComponent<BoxCollider> ().enabled = false;

		return true;
	}
}
