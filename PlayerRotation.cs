//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {
	public Transform trBullet;
	public Transform trShootPoint;
	public float bulletForce; //Bullet Force = 500

	private bool isLockedOn;

	public void LockOnEnemy (Transform trEnemy) {
		isLockedOn = true;
		Vector2 enemyPos = trEnemy.position;

		float angleRad = Mathf.Atan2 (enemyPos.y - transform.position.y, enemyPos.x - transform.position.x);
		float angleDeg = (180 / Mathf.PI) * angleRad - 90f;

		transform.rotation = Quaternion.Euler (0f, 0f, angleDeg);
	} 

	public void UnLockOnEnemy () {
		isLockedOn = false;
	}

	public void ShootBullet (EnemyText enemyTarget) {
		Transform enemyGO = Instantiate (trBullet, trShootPoint.position, transform.rotation);
		enemyGO.GetComponent<BulletMovement> ().targetEnemy = enemyTarget;
		enemyGO.GetComponent<BulletMovement> ().isNotLastBullet = isLockedOn;
		enemyGO.GetComponent<Rigidbody2D> ().AddForce (trShootPoint.up * bulletForce);
	}
}
