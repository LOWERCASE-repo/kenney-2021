using UnityEngine;
using TMPro;
// using UnityEngine.UI;
using UnityEngine.SceneManagement;

class LevelName : MonoBehaviour {
	
	[SerializeField] TMP_Text text;
	
	void OnEnable() {
		Scene scene = SceneManager.GetActiveScene();
		text.text = $"{scene.buildIndex}. {scene.name}";
	}
}
