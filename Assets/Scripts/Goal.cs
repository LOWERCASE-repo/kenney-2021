using UnityEngine;

class Goal : MonoBehaviour {
	
	[SerializeField] SpriteRenderer sprite;
	[SerializeField] Sprite open, filled;
	
	void OnDisable() {
		sprite.sprite = open;
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		sprite.sprite = filled;
		collider.GetComponent<Animator>().SetTrigger("Goal");
		
	}
}
