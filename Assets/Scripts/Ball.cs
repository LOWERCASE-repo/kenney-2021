using UnityEngine;
using System.Collections;

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

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.relativeVelocity.magnitude < 4f && Synchronizer.Self.isPlay) return;
		source.PlayOneShot(bounceSounds[Random.Range(0, bounceSounds.Length)]);
	}

	internal void EebyDeebyify() {
		transform.position += Vector3.up * 868031011794f;
	}
	
	internal IEnumerator EebyCoru() {
		yield return new WaitForSeconds(1f / 3f);
		transform.position += Vector3.up * 868031011794f;
	}
}
