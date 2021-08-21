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
			if (Input.GetKeyDown("left") || Input.GetKeyDown("a") || Input.GetKeyDown("q")) {
				transform.Rotate(new Vector3(0, 0, 90));
            } else if (Input.GetKeyDown("right") || Input.GetKeyDown("e") || Input.GetKeyDown("d")) {
				transform.Rotate(new Vector3(0, 0, -90));
			}
			if (Input.GetMouseButtonUp(0)) {
				sprite.sortingLayerName = "Default";
				if (placements.GetTile(poll) != null) PutDown();
				else {
					Destroy(gameObject);
					generator.IncrementTNH();
				}
			}
		}
	}
	
	private void OnMouseDown() {
		sprite.sortingLayerName = "Placements";
		PickUp();
	}

    private void OnMouseOver() {
		if (!Synchronizer.Self.isPlay) {
			sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 150f / 255);
		}
    }

    private void OnMouseExit() {
		sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
	}

    public void PickUp() {
		gameObject.layer = 6;
		print("picked up");
		isHeld = true;
	}
	
	void PutDown() {
		
		gameObject.layer = 0;

		print("put down");
		isHeld = false;
	}
	
}
