using UnityEngine;

class Ball : Synchro {
	
	Rigidbody2D body;
	Vector3 spawnPos;
	[SerializeField] Animator animator;
	
	[SerializeField] AudioSource source;
	[SerializeField] AudioClip[] bounceSounds;
	
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
	
	void OnCollisionEnter2D() {
		if (body.velocity.sqrMagnitude > 6f) source.PlayOneShot(bounceSounds[Random.Range(0, bounceSounds.Length)]);
	}
	
	void EebyDeebyify() {
		transform.position += Vector3.down * 1085072238237f;
	}
}
