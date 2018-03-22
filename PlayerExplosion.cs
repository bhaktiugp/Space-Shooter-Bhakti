//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerExplosion : MonoBehaviour {
	public GameObject playerModel;
	public Transform playerExploder;

	public void StartExploding () {
		Transform exploderGO = Instantiate (playerExploder, transform.position, transform.rotation);
		Destroy (exploderGO.gameObject, 1f);
		playerModel.SetActive (false);
		Invoke ("GameoverScene", 1.5f);
	}

	void GameoverScene () {
		SceneManager.LoadScene ("Gameover");
	}
}
