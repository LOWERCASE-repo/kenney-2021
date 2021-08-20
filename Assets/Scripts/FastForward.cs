using UnityEngine;

class FastForward : MonoBehaviour {

	bool isFast;
	float baseSpeed;
	[SerializeField] float multiplier;
	
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
		isFast = !isFast;
		if (isFast) {
			OnDisable();
        } else {
			OnEnable();
        }
    }
}
