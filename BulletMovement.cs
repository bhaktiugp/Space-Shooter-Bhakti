//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {
	public EnemyText targetEnemy;
	public Transform bulletExploder;
	public bool isNotLastBullet;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag.Equals ("Enemy")) {

			if (other.GetComponent<EnemyText> () == targetEnemy) {
				Transform exploderGO = Instantiate (bulletExploder, transform.position, transform.rotation);
				Destroy (exploderGO.gameObject, 1f);
				Destroy (gameObject);	
			}
		}
	}
}
