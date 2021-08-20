using UnityEngine;

class FastForward : MonoBehaviour {
	
	float baseSpeed;
	[SerializeField] float multiplier;
	
	void Awake() {
		baseSpeed = Time.timeScale;
	}
	
	void OnEnable() {
		Time.timeScale = baseSpeed * multiplier;
	}
	
	void OnDisable() {
		Time.timeScale = baseSpeed;
	}
}
