using UnityEngine;

class Synchronizer : MonoBehaviour {
	
	internal static Synchronizer Self;
	
	void OnAwake() => Self = this;
	
	void OnEnable() {
		GameObject[] synchros = GameObject.FindGameObjectsWithTag("Synchro");
		foreach (GameObject gameObject in synchros) {
			gameObject.GetComponent<Synchro>().enabled = true;
		}
	}
	
	void OnDisable() {
		GameObject[] synchros = GameObject.FindGameObjectsWithTag("Synchro");
		foreach (GameObject gameObject in synchros) {
			gameObject.GetComponent<Synchro>().enabled = false;
		}
	}
}
