using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

class Generator : Synchro
{
	Transform parent;
	[SerializeField]
	Image image;
	[SerializeField]
	Button button;
	[SerializeField]
	TMP_Text text;
	
	[Header("Touch me")] 
	[SerializeField]
	GameObject prefab;
	[SerializeField]
	int tileNum;
	
	private int tileNumHide;
	
	private void Start() {
		tileNumHide = tileNum;
		parent = Synchronizer.Self.playerPieces;
	}
	private void OnEnable() {
		Sprite s = prefab.GetComponent<SpriteRenderer>().sprite;
		image.sprite = s;
		tileNumHide = tileNum;
		if (tileNumHide > 0) {
			button.interactable = true;
		}
		text.text = tileNumHide.ToString();
	}
	
	private void OnDisable() {
		tileNumHide = tileNum;
	}
	
	public void Generate () {
		if (tileNumHide > 0) {
			Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);
			GameObject g = Instantiate(prefab, mousePos, Quaternion.identity, parent);
			Draggable drag = g.AddComponent<Draggable>();
			drag.PickUp();
			
			tileNumHide--;
			text.text = tileNumHide.ToString();
			if (tileNumHide == 0) {
				button.interactable = false;
			}
		}
	}
}
