//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class EnemySummoner : MonoBehaviour {
	public Transform enemyPrefab;
	public Transform trPlayer;
	public int maxChars; //Max Characters = 3
	public float enemyForce; //Enemy Force = 25

	private int charIndex;

	public void SetEnemyString (string strValue) {
		char[] targetChars = strValue.ToCharArray ();
		string someChars = "";
		int charAmount = 0;

		if (Data.score < 150) {
			charAmount += maxChars;
		} else if (Data.score < 300) {
			charAmount += maxChars + 1;
		} else if (Data.score < 700) {
			charAmount += maxChars + 3;
		} else {
			charAmount = maxChars + 5;
		}

		for (int i = 0; i < charAmount; i++) {
			charIndex = Random.Range (0, targetChars.Length);
			someChars += targetChars [charIndex].ToString ();
		}

		SummonEnemy (someChars, enemyForce);
	}

	public void SummonEnemy (string targetString, float targetForce) {
		Vector2 newPosition = new Vector2 (Random.Range (-3f, 3f), transform.position.y);
		Transform enemyGO = Instantiate (enemyPrefab, newPosition, enemyPrefab.rotation);

		enemyGO.GetComponent<EnemyText> ().SetString (targetString);	
		enemyGO.GetComponent<EnemyMovement> ().Move (trPlayer.position, targetForce);
	}
}
