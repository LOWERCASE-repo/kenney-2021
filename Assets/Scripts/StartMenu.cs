using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

class StartMenu : MonoBehaviour {
	
	[SerializeField] Animator animator;
	
	public void TriggerFade() {
		animator.SetTrigger("Complete");
		StartCoroutine(SwitchScene());
	}
	
	IEnumerator SwitchScene() {
		yield return new WaitForSeconds(0.25f);
		SceneManager.LoadScene(0);
	}
}
