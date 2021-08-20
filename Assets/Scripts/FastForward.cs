using UnityEngine;
using UnityEngine.UI;

class FastForward : MonoBehaviour {

	bool isFast;
	float baseSpeed;
	[SerializeField] float multiplier;
	[SerializeField] Sprite fast;
	[SerializeField] Sprite slow;
	[SerializeField] Image button;
	
	void Awake() {
		isFast = false;
		baseSpeed = Time.timeScale;
	}
	
	void OnEnable() {
		Time.timeScale = baseSpeed * multiplier;
	}
	
	void OnDisable() {
		Time.timeScale = baseSpeed;
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
