//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyName : MonoBehaviour {

	private GameMaster instanceGM {
		get { 
			return GameMaster.Instance;
		}
	}

	private Text textKeyName;

	void Awake () {
		textKeyName = GetComponentInChildren<Text> ();
		textKeyName.text = gameObject.name;
	}

	public void EnterStrKey () {
		instanceGM.CheckList (textKeyName.text);
	}
}
