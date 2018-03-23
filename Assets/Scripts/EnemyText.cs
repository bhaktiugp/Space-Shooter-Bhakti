//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyText : MonoBehaviour {
	public Transform enemyExploder;
	public List<string> listOfStrings;
	public Text textEnemy;
	public GameObject lockOnImage;

	private GameMaster instanceGM {
		get { 
			return GameMaster.Instance;
		}
	}

	private bool isDestroyed;

	void Awake () {
		textEnemy = GetComponentInChildren<Text> ();
	}

	public void SetString (string enemyString) {
		char[] arrayOfChars = enemyString.ToCharArray();

		for (int i = 0; i < arrayOfChars.Length; i++) {
			listOfStrings.Add (arrayOfChars [i].ToString());
		}

		instanceGM.AddEnemy (transform, listOfStrings[0]);
		PrintString (listOfStrings);
	}

	public void DeleteString () {
		listOfStrings.RemoveAt (0);
		PrintString (listOfStrings);
	}

	public void DestroyEnemy () {
		instanceGM.listOfEnemies.RemoveAt (instanceGM.selectedEnemy);
		instanceGM.listOfStringKeys.RemoveAt (instanceGM.selectedEnemy);
		instanceGM.isEnemyLocked = false;

		isDestroyed = true;
	}

	void PrintString (List<string> strings) {
		string printedString = "";

		for (int i = 0; i < strings.Count; i++) {
			printedString += strings [i].ToString ();
		}

		textEnemy.text = printedString;
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.tag.Equals ("Player") && !instanceGM.isPlayerLose) {
			other.GetComponent<PlayerExplosion> ().StartExploding ();
			instanceGM.isPlayerLose = true;
			return;
		}

		if (other.tag.Equals ("Bullet")) {
			
			if (isDestroyed && !other.GetComponent<BulletMovement> ().isNotLastBullet) {
				Transform exploderGO = Instantiate (enemyExploder, transform.position, transform.rotation);
				Destroy (exploderGO.gameObject, 1f);
				Destroy (gameObject);
			}
		}
	}
}
