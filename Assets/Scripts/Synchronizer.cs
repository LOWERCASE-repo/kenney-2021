using UnityEngine;
using System.Collections.Generic;

class Synchronizer : MonoBehaviour {
	
	internal static Synchronizer Self;
	[SerializeField] internal Grid grid;
	[SerializeField] internal Transform playerPieces;
	List<Goal> goals = new List<Goal>();
	
	void Awake() => Self = this;
	
	void OnEnable() {
		GameObject[] synchros = GameObject.FindGameObjectsWithTag("Synchro");
		foreach (GameObject gameObject in synchros) {
			gameObject.
			gameObject.GetComponent<Synchro>().enabled = true;
		}
	}
	
	void OnDisable() {
		GameObject[] synchros = GameObject.FindGameObjectsWithTag("Synchro");
		foreach (GameObject gameObject in synchros) {
			gameObject.GetComponent<Synchro>().enabled = false;
		}
		goals.Clear();
	}
	
	internal void RegisterGoal(Goal goal) {
		goals.Add(goal);
	}
	
	internal void CloseGoal(Goal goal) {
		goals.Remove(goal);
		if (goals.Count == 0) print("B U N G U S");
	}
}
