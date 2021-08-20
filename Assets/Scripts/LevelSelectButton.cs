using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour
{
	
	[Header("values set by scripts")]
	public string levelName;
	public LevelSelect manager;
	public Animator fader;
	
	public void Load() {
		fader.SetTrigger("FadeOut");
		StartCoroutine(LoadForReal());
	}
	
	IEnumerator LoadForReal() {
		yield return new WaitForSeconds(0.25f);
		SceneManager.LoadScene(levelName);
	}
	
	public void SetTitle() {
		manager.SetTitle(levelName.ToUpperInvariant());
	}
}
