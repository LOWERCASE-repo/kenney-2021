using UnityEngine;

class Ball : Synchro {
	
	// [SerializeField] float speed;
	Rigidbody2D body;
	Vector3 spawnPos;
	[SerializeField] Animator animator;
	
	void OnEnable() {
		body = GetComponent<Rigidbody2D>();
		spawnPos = transform.localPosition;
		body.isKinematic = false;
	}
	
	void OnDisable() {
		transform.localPosition = spawnPos;
		body.isKinematic = true;
		body.velocity = Vector2.zero;
		body.angularVelocity = 0f;
		transform.localRotation = Quaternion.identity;
		animator.SetTrigger("Reset");
	}
	
	// internal void Goal() {
	// 	animator.SetTrigger("Goal");
	// }
}
