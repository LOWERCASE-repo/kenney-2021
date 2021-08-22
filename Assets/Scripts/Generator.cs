using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

class Generator : MonoBehaviour
{
	Transform parent;
	[SerializeField]
	Image image;
	[SerializeField]
	public Button button;
	[SerializeField]
	TMP_Text text;
	public bool interactable;

	[Header("Touch me")] 
	[SerializeField]
	GameObject prefab;
	[SerializeField]
	int tileNum;


	
	public int tileNumHide;
	internal void IncrementTNH() {
		tileNumHide++;
		text.text = tileNumHide.ToString();
		if (tileNumHide > 0) {
			button.interactable = true;
			interactable = true;
		}
	}
	
	private void Start() {
		tileNumHide = tileNum;
		parent = Synchronizer.Self.playerPieces;
	}
	private void OnEnable() {
		image.sprite = prefab.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
		tileNumHide = tileNum;
		if (tileNumHide > 0) {
			button.interactable = true;
			interactable = true;
		}
		text.text = tileNumHide.ToString();
	}
	
	public void Generate () {
		if (interactable && !Synchronizer.Self.isPlay) {
			Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);
			GameObject g = Instantiate(prefab, mousePos, Quaternion.identity, parent);
			Draggable drag = g.AddComponent<Draggable>();
			drag.generator = this;
			drag.PickUp();
			
			tileNumHide--;
			text.text = tileNumHide.ToString();
			if (tileNumHide == 0) {
				button.interactable = false;
				interactable = false;
			}
		}
	}
}
