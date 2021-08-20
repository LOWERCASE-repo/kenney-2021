using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelect : MonoBehaviour
{
	
	[Header("Set these in editor")]
	[SerializeField] int COLS, ROWS;
	[SerializeField] Transform levelGridLayout;
	[SerializeField] Button prevButton;
	[SerializeField] Button nextButton;
	[SerializeField] LevelSelectButton levelButton;
	[SerializeField] TextMeshProUGUI titleText;
	[SerializeField] Animator fader;
	
	//public List<Scene> levels;
	public int levelIndexStart, levelIndexEnd;
	List<string> levelNames;
	
	//Mock values
	[Header("Debug, do not edit.")]
	public int pageNumber = 0;
	public int levelCount;
	
	// Start is called before the first frame update
	void Start() {
		levelNames = new List<string>();
		//Get levels
		for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++) {
			string currentScene = SceneUtility.GetScenePathByBuildIndex(i);
			print(currentScene);
			currentScene = currentScene.Substring(currentScene.LastIndexOf("/") + 1, currentScene.LastIndexOf(".") - currentScene.LastIndexOf("/") - 1);
			if (!currentScene.Equals("Level Select") && !currentScene.Equals("Main Menu")) {
				levelNames.Add(currentScene);
			}
		}
		levelCount = levelNames.Count;
		
		LoadLevels();
	}
	
	void LoadLevels() {
		int startIndex = pageNumber * (COLS * ROWS);
		foreach (Transform child in levelGridLayout) {
			Destroy(child.gameObject);
		}
		for (int i = startIndex; i < startIndex + COLS * ROWS; i++) {
			if (i < levelCount) {
				LevelSelectButton button = Instantiate(levelButton, levelGridLayout);
				button.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = string.Format("{0}", i + 1);
				button.manager = this;
				button.fader = fader;
				if (i < levelNames.Count) {
					button.levelName = levelNames[i];
				} else {
					button.levelName = "You didn't set enough level names. No seriously, you have to fix this.";
				}
			}
		}
		
		prevButton.interactable = pageNumber > 0;
		nextButton.interactable = pageNumber < ((levelCount + COLS * ROWS - 1) / (COLS * ROWS) - 1);
	}
	
	public void Prev() {
		if (pageNumber > 0) {
			pageNumber--;
		}
		LoadLevels();
	}
	
	public void Next() {
		if (pageNumber < ((levelCount + COLS * ROWS - 1) / (COLS * ROWS) - 1)) {
			pageNumber++;
		}
		LoadLevels();
	}
	
	public void SetTitle(string text) {
		titleText.text = text;
	}
}
