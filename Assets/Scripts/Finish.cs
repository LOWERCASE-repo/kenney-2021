using UnityEngine;

class Finish : MonoBehaviour {
	
	[SerializeField] AudioSource source;
	[SerializeField] AudioClip[] clips;
	[SerializeField] FastForward fastForward;
	
	void RestoreTime() {
		if (fastForward.isFast) fastForward.ButtonToggle();
	}
	
	void PlayJingle() {
		source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
	}
	
	void TransitionLevelSelect() {
		print("if level select existed, i'd redirect ya now");
	}
	
}
