using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

class Synchronizer : MonoBehaviour {
	
	internal static Synchronizer Self;
	[SerializeField] internal bool isPlay;
	[SerializeField] internal Grid grid;
	[SerializeField] internal Transform playerPieces;
	[SerializeField] Transform Buttons;
	[SerializeField] Animator fader;
	[SerializeField] TilemapRenderer placementsRenderer;
	List<Goal> goals = new List<Goal>();
	
	void Awake() => Self = this;
	
	// TODO clear on reset
	internal HashSet<Vector3Int> currentPieces = new HashSet<Vector3Int>();
	
	void Start() {
		currentPieces.Clear();
	}
	
	void OnEnable() {
		isPlay = true;
		GameObject[] synchros = GameObject.FindGameObjectsWithTag("Synchro");
		foreach (GameObject gameObject in synchros) {
			gameObject.GetComponent<Synchro>().enabled = true;
		}
		placementsRenderer.enabled = false;
	}
	
	void OnDisable() {
		isPlay = false;
		GameObject[] synchros = GameObject.FindGameObjectsWithTag("Synchro");
		foreach (GameObject gameObject in synchros) {
			gameObject.GetComponent<Synchro>().enabled = false;
		}
		goals.Clear();
		placementsRenderer.enabled = true;
	}
	
	internal void RegisterGoal(Goal goal) {
		goals.Add(goal);
	}
	
	internal void CloseGoal(Goal goal) {
		goals.Remove(goal);
		if (goals.Count == 0) fader.SetTrigger("Complete");
	}

    public void play() {
		OnEnable();
		foreach (Generator g in Buttons.GetComponentsInChildren<Generator>()) {
			g.button.interactable = false;
			g.interactable = false;
		}
	}

	public void restart() {
		OnDisable();
		foreach (Generator g in Buttons.GetComponentsInChildren<Generator>()) {
			if (g.tileNumHide > 0) {
				g.button.interactable = true;
				g.interactable = true;
			}
		}
	}
}
