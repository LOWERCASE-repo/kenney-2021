using UnityEngine;

class Rotator : Synchro {
	
	[SerializeField] internal float speed;
	Rigidbody2D body;
	
	bool rotating;
	
	void OnEnable() {
		// do the spinny thing
		// body = GetComponent<Rigidbody2D>();
		// body.angularVelocity = speed;
		rotating = true;
	}
	
	void OnDisable() {
		rotating = false;
		// body.angularVelocity = 0f;
		transform.rotation = Quaternion.identity;
	}
	
	void FixedUpdate() {
		if (!rotating) return;
		transform.rotation = Quaternion.AngleAxis(transform.rotation.eulerAngles.z + speed * Time.deltaTime, Vector3.forward);
	}
}
