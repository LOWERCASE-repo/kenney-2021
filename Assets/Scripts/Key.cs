using UnityEngine;

class Key : Synchro {
	
	Vector3 spawnPos;
	[SerializeField] GameObject door;
	[SerializeField] SpriteRenderer sprite;
	
	[SerializeField] AudioSource source;
	[SerializeField] AudioClip[] sounds;
	
	void OnEnable() {
		spawnPos = transform.localPosition;
	}
	
	void OnDisable() {
		sprite.enabled = true;
		transform.localPosition = spawnPos;
		door.SetActive(true);
	}
	
	void OnTriggerEnter2D() {
		if (!sprite.enabled || !Synchronizer.Self.isPlay) return;
		door.SetActive(false);
		sprite.enabled = false;
		source.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
	}
}
