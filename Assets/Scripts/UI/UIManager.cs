using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public static UIManager _instance;

	public static UIManager Instance { get { return _instance; } }

	//UI Elements
	public UILabel HealthLabel;
	public UILabel CollectedLabel;
	public UILabel ElapsedLabel;

	public GameObject MainMenu;

	void Awake() {
		_instance = this;
	}
		
}
