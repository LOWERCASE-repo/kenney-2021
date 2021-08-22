using UnityEngine;
using System.Collections;

class Goal : Synchro {
	
	[SerializeField] SpriteRenderer sprite;
	[SerializeField] Sprite open, filled;
	[SerializeField] CircleCollider2D circle;
	
	[SerializeField] AudioSource source;
	[SerializeField] AudioClip[] sounds;
	
	void OnEnable() {
		Synchronizer.Self.RegisterGoal(this);
	}
	
	void OnDisable() {
		sprite.sprite = open;
		circle.enabled = true;
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		if (!Synchronizer.Self.isPlay) return;
		sprite.sprite = filled;
		collider.GetComponent<Animator>().SetTrigger("Goal");
		StartCoroutine(collider.GetComponent<Ball>().EebyCoru());
		circle.enabled = false;
		Synchronizer.Self.CloseGoal(this);
		source.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
	}
}
