//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BGMManager : MonoBehaviour {
	public AudioClip[] audioClips;

	private AudioSource audioS;

	void Awake () {
		DontDestroyOnLoad (this);
		audioS = GetComponent<AudioSource> ();
	}

	void Update () {
		if (!audioS.enabled) {
			return;
		}

		if (SceneManager.GetActiveScene ().name == "Menu") {
			SetClip (0);
		}
		else {
			SetClip (1);
		}
	}

	void SetClip (int clipIndex) {
		audioS.clip = audioClips [clipIndex];

		if (!audioS.isPlaying) {
			audioS.Play ();
		}
	}
}
