using UnityEngine;

class Spring : MonoBehaviour {
	
	[SerializeField] Sprite spring, sprung;
	SpriteRenderer sprite;
	[SerializeField] float force;
	
	[SerializeField] AudioSource source;
	[SerializeField] AudioClip[] sounds;
	
	void OnEnable() {
		sprite = GetComponent<SpriteRenderer>();
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		if (gameObject.layer != 6) {
			// collider.GetComponent<Rigidbody2D>().velocity = transform.up * force;
			collider.GetComponent<Rigidbody2D>().AddForce(transform.up * force, ForceMode2D.Impulse);
			sprite.sprite = spring;
			source.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
		}
	}
	
	void OnTriggerExit2D(Collider2D collider) {
		if (gameObject.layer != 6) {
			sprite.sprite = sprung;
		}
	}
}
