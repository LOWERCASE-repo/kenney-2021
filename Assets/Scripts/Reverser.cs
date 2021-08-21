using UnityEngine;

class Reverser : Synchro {
	
	Vector3 spawnPos;
	float oldSpeed;
	[SerializeField] internal float newSpeed;
	[SerializeField] SpriteRenderer sprite;
	
	[SerializeField] AudioSource source;
	[SerializeField] AudioClip[] sounds;
	
	void OnEnable() {
		spawnPos = transform.localPosition;
		oldSpeed = Synchronizer.Self.GetComponent<Rotator>().speed;
	}
	
	void OnDisable() {
		sprite.enabled = true;
		transform.localPosition = spawnPos;
		Synchronizer.Self.GetComponent<Rotator>().speed = oldSpeed;
	}
	
	void OnTriggerEnter2D() {
		if (!sprite.enabled) return;
		sprite.enabled = false;
		source.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
		Synchronizer.Self.GetComponent<Rotator>().speed = newSpeed;
	}
	
}
