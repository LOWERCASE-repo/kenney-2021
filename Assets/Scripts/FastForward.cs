using UnityEngine;
using UnityEngine.UI;

class FastForward : MonoBehaviour {

	internal bool isFast;
	public float baseSpeed;
	[SerializeField] float multiplier;
	[SerializeField] Sprite fast;
	[SerializeField] Sprite slow;
	[SerializeField] Image button;
	
	[SerializeField] AudioSource source;
	[SerializeField] AudioClip[] fastSound, slowSound;
	
	void Awake() {
		isFast = false;
		baseSpeed = Time.timeScale;
	}
	
	void OnEnable() {
		Time.timeScale = baseSpeed * multiplier;
		source.PlayOneShot(fastSound[Random.Range(0, fastSound.Length)]);
	}
	
	void OnDisable() {
		Time.timeScale = baseSpeed;
		source.PlayOneShot(slowSound[Random.Range(0, slowSound.Length)]);
	}

	public void ButtonToggle () {
		if (isFast) {
			OnDisable();
			button.sprite = fast;
        } else {
			OnEnable();
			button.sprite = slow;
        }
		isFast = !isFast;
	}
}
