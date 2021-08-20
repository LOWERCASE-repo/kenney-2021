using UnityEngine;

class Key : Synchro {
	
	Vector3 spawnPos;
	[SerializeField] GameObject door;
	[SerializeField] SpriteRenderer sprite;
	
	void OnEnable() {
		spawnPos = transform.localPosition;
	}
	
	void OnDisable() {
		sprite.enabled = true;
		transform.localPosition = spawnPos;
		door.SetActive(true);
	}
	
	void OnTriggerEnter2D() {
		door.SetActive(false);
		sprite.enabled = false;
	}
}
