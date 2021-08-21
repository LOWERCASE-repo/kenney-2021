using UnityEngine;

class BallButton : Synchro {
	
	[SerializeField] Sprite buttonUp, buttonDown;
	SpriteRenderer sprite;
	[SerializeField] Platform[] platforms;
	
	[SerializeField] AudioSource source;
	[SerializeField] AudioClip[] sounds;
	
	void OnEnable() {
		sprite = GetComponent<SpriteRenderer>();
		SwapAll();
	}
	
	void OnDisable() {
		sprite.sprite = buttonUp;
		SwapAll();
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		if (gameObject.layer != 6) {
			// collider.GetComponent<Rigidbody2D>().velocity = transform.up * force;
			// collider.GetComponent<Rigidbody2D>().AddForce(transform.up * force, ForceMode2D.Impulse);
			sprite.sprite = buttonDown;
			SwapAll();
			source.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
		}
	}
	
	void OnTriggerExit2D(Collider2D collider) {
		if (gameObject.layer != 6) {
			sprite.sprite = buttonUp;
			SwapAll();
			source.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
		}
	}

	void SwapAll() {
		foreach (Platform g in platforms) {
			g.Swap();
		}
	}
}
