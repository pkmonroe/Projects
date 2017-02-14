using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject debrisPrefab;

	public const short numDebrisPieces = 10;

	void Start () {

		for (int i = 0; i < numDebrisPieces; i++) {
			Instantiate(debrisPrefab, new Vector3( i * 10, 1, 0), Quaternion.identity);
		}
	}
		

}
