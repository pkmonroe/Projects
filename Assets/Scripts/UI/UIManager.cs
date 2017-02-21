using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public static UIManager _instance;

	public static UIManager Instance { get { return _instance; } }

	//UI Elements
	public UILabel ScoreLabel;

	void Awake() {
		_instance = this;
	}
		
}
