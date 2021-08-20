using UnityEngine;

class Ball : Synchro {
	
	// [SerializeField] float speed;
	Rigidbody2D body;
	Vector3 spawnPos;
	
	void OnEnable() {
		body = GetComponent<Rigidbody2D>();
		spawnPos = transform.localPosition;
		body.isKinematic = false;
	}
	
	void OnDisable() {
		transform.localPosition = spawnPos;
		body.isKinematic = true;
		body.velocity = Vector2.zero;
	}
}
