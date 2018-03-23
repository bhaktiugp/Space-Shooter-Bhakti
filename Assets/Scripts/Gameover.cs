//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour {
	public Text textScore;
	public Text textHighscore;

	private int highscore;

	void Awake () {
		highscore = PlayerPrefs.GetInt ("HS", 0);

		if (Data.score > highscore) {
			highscore = Data.score;
			PlayerPrefs.SetInt ("HS", highscore);
		}

		textScore.text = "Your Score " + Data.score.ToString ();
		textHighscore.text = "Highscore " + highscore;
	}

	public void RestartGame () {
		SceneManager.LoadScene ("Gameplay");
	}

	public void MainMenu () {
		SceneManager.LoadScene ("Menu");
	}
}
