using UnityEngine;

class Spring : MonoBehaviour {
	
	[SerializeField] Sprite spring, sprung;
	SpriteRenderer sprite;
	[SerializeField] float force;
	
	void OnEnable() {
		sprite = GetComponent<SpriteRenderer>();
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		// collider.GetComponent<Rigidbody2D>().velocity = transform.up * force;
		collider.GetComponent<Rigidbody2D>().AddForce(transform.up * force, ForceMode2D.Impulse);
		sprite.sprite = spring;
	}
	
	void OnTriggerExit2D(Collider2D collider) {
		sprite.sprite = sprung;
	}
}
