using UnityEngine;

class Rotator : Synchro {
	
	[SerializeField] float speed;
	Rigidbody2D body;
	
	void OnEnable() {
		// do the spinny thing
		body = GetComponent<Rigidbody2D>();
		body.angularVelocity = speed;
	}
	
	void OnDisable() {
		body.angularVelocity = 0f;
		transform.rotation = Quaternion.identity;
	}
}
