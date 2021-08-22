using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

class Draggable : MonoBehaviour {
	[SerializeField] bool isHeld;
	[SerializeField] Grid grid;
	[SerializeField] Tilemap placements;
	[SerializeField] SpriteRenderer sprite;
	float angle;
	
	Camera cam;
	Vector3Int poll;
	
	internal Generator generator;
	
	private void Start() {
		cam = Camera.main;
		sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
		grid = Synchronizer.Self.grid;
		placements = grid.transform.GetChild(0).GetComponent<Tilemap>();
		sprite.sortingLayerName = "Placements";
		angle = gameObject.tag.Equals("Spring") ? 45f : 90f;
	}
	
	private void Update() {
		if (isHeld) {
			Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
			mousePos.z = 0f;
			poll = grid.WorldToCell(mousePos);
			transform.position = grid.GetCellCenterLocal(poll);
			if (Input.GetKeyDown("left") || Input.GetKeyDown("a") || Input.GetKeyDown("q")) {
				transform.Rotate(new Vector3(0, 0, angle));
				} else if (Input.GetKeyDown("right") || Input.GetKeyDown("e") || Input.GetKeyDown("d")) {
					transform.Rotate(new Vector3(0, 0, -angle));
				}
				if (Input.GetMouseButtonUp(0)) {
					sprite.sortingLayerName = "Default";
					if (placements.GetTile(poll) != null && !Synchronizer.Self.currentPieces.Contains(poll)) {
						PutDown();
						Synchronizer.Self.currentPieces.Add(poll);
					} else {
						Destroy(gameObject);
						generator.IncrementTNH();
					}
				}
			}
		}
		
		private void OnMouseDown() {
			if (!Synchronizer.Self.isPlay) {
				sprite.sortingLayerName = "Placements";
				Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
				mousePos.z = 0f;
				Vector3Int poll = grid.WorldToCell(mousePos);
				Synchronizer.Self.currentPieces.Remove(poll);
				PickUp();
			}
		}
		
		private void OnMouseOver() {
			if (!Synchronizer.Self.isPlay) {
				sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 150f / 255);
			}
		}
		
		private void OnMouseExit() {
			if (isHeld) return;
			sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
		}
		
		public void PickUp() {
			gameObject.layer = 3;
			foreach(Transform t in gameObject.transform) {
				t.gameObject.layer = 2;
			}
			isHeld = true;
		}
		
		void PutDown() {
			
			gameObject.layer = 6;
			foreach (Transform t in gameObject.transform) {
				t.gameObject.layer = 2;
			}
			isHeld = false;
		}
		
	}
