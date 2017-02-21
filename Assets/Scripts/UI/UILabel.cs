using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILabel : MonoBehaviour {

	private Text textLabel;

	void Awake(){
		textLabel = GetComponent<Text> ();
	}

	public void SetText(string _text){
		textLabel.text = _text;
	}
}
