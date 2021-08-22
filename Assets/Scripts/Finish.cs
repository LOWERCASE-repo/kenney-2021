using UnityEngine;
using UnityEngine.SceneManagement;

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
	
	public void TransitionLevelSelect() {
		SceneManager.LoadScene(1);
	}
	
	public void Restart() {
		Time.timeScale = fastForward.baseSpeed;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	void TransitionNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
}
