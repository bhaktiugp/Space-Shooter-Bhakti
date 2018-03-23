//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {
	public Text textScore;
	public List<Transform> listOfEnemies;
	public List<string> listOfStringKeys;
	public bool isEnemyLocked;
	public int selectedEnemy;
	public int charScore; //Char Score = 10
	public bool isPlayerLose;

	public static GameMaster Instance {
		get { 
			if (!instance) {
				instance = FindObjectOfType<GameMaster> ();
			}
			return instance;
		}
	}
	private static GameMaster instance;

	private EnemyText scrEnemyText;
	private EnemySummoner scrEnemySummoner;
	private string stringBase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

	void Awake () {
		Data.score = 0;
		scrEnemySummoner = GetComponent<EnemySummoner> ();

		InvokeRepeating("StartSummonEnemy",0f,3f);
	}

	void StartSummonEnemy () {
		scrEnemySummoner.SetEnemyString (stringBase);
	}

	public void AddEnemy (Transform trEnemy, string primaryStr) {
		listOfEnemies.Add (trEnemy);
		listOfStringKeys.Add (primaryStr);
	}

	public void CheckList (string keyboardStr) {

		if (isPlayerLose) {
			return;
		}
		
		if (isEnemyLocked) {
			CheckString (keyboardStr);
			return;
		}

		for (int i = 0; i < listOfStringKeys.Count; i++) {

			if (keyboardStr.Equals (listOfStringKeys [i])) {
				isEnemyLocked = true;
				selectedEnemy = i;
				scrEnemySummoner.trPlayer.GetComponent<PlayerRotation> ().LockOnEnemy (listOfEnemies [selectedEnemy]);
				CheckString (keyboardStr);
				return;
			}
		}
	}

	void CheckString (string strKey) {

		if (!strKey.Equals (listOfStringKeys [selectedEnemy])) {
			return;
		}
			
		scrEnemyText = listOfEnemies [selectedEnemy].GetComponent<EnemyText> ();
		scrEnemyText.lockOnImage.SetActive (true);
		scrEnemyText.DeleteString ();
		Data.score += charScore;
		textScore.text = Data.score.ToString ();

		if (scrEnemyText.listOfStrings.Count.Equals (0)) {
			scrEnemyText.DestroyEnemy ();
			scrEnemySummoner.trPlayer.GetComponent<PlayerRotation> ().UnLockOnEnemy ();
		}
		else {
			listOfStringKeys [selectedEnemy] = scrEnemyText.listOfStrings [0];
		}

		scrEnemySummoner.trPlayer.GetComponent<PlayerRotation> ().ShootBullet (scrEnemyText);
	}
}
