using UnityEngine;

class Goal : Synchro {
	
	[SerializeField] SpriteRenderer sprite;
	[SerializeField] Sprite open, filled;
	[SerializeField] CircleCollider2D circle;
	
	void OnEnable() {
		Synchronizer.Self.RegisterGoal(this);
	}
	
	void OnDisable() {
		sprite.sprite = open;
		circle.enabled = true;
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		sprite.sprite = filled;
		collider.GetComponent<Animator>().SetTrigger("Goal");
		circle.enabled = false;
		Synchronizer.Self.CloseGoal(this);
	}
}
