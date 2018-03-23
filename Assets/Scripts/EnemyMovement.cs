//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	
	public void Move (Vector3 playerPosition, float force) {
		Vector3 direction = (playerPosition - transform.position).normalized;
		GetComponent<Rigidbody2D> ().AddForce (direction * force);
	}
}
