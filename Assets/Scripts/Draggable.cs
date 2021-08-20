using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Draggable : MonoBehaviour
{
	[SerializeField]
	bool isHeld;
	[SerializeField]
	Grid grid;
	[SerializeField]
	Tilemap placements;
	[SerializeField]
	SpriteRenderer sprite;
	
	Camera cam;
	Vector3Int poll;
	
	internal Generator generator;
	
	private void Start() {
		cam = Camera.main;
		sprite = GetComponent<SpriteRenderer>();
		grid = Synchronizer.Self.grid;
		placements = grid.transform.GetChild(1).GetComponent<Tilemap>();
	}
	
	private void Update() {
		if (isHeld) {
			Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
			mousePos.z = 0f;
			poll = grid.WorldToCell(mousePos);
			transform.position = grid.GetCellCenterLocal(poll);
		}
	}
	
	private void OnMouseDown() {
		sprite.sortingLayerName = "Placements";
		PickUp();
	}
	
	private void OnMouseUp() {
		sprite.sortingLayerName = "Default";
		if (placements.GetTile(poll) != null) PutDown();
		else {
			Destroy(gameObject);
			generator.IncrementTNH();
		}
	}
	
	public void PickUp() {
		gameObject.layer = 6;
		print("picked up");
		isHeld = true;
	}
	
	void PutDown() {
		
		gameObject.layer = 7;

		print("put down");
		isHeld = false;
	}
	
}
