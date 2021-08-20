using UnityEngine;

class Ball : Synchro {
	
	// [SerializeField] float speed;
	Rigidbody2D body;
	Vector2 spawnPos;
	
	void OnEnable() {
		body = GetComponent<Rigidbody2D>();
		spawnPos = body.position;
		body.isKinematic = false;
	}
	
	void OnDisable() {
		body.position = spawnPos;
		body.isKinematic = true;
		body.velocity = Vector2.zero;
	}
}
