using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
	[SerializeField]
	bool isHeld;
	[SerializeField]
	Grid grid;
	
	private void Start() {
		grid = Synchronizer.Self.grid;
	}
	
	private void Update() {
		if (isHeld) {
			Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);
			transform.position = grid.GetCellCenterLocal(grid.WorldToCell(mousePos));
		}
	}
	
	private void OnMouseDown() {
		PickUp();
	}
	
	private void OnMouseUp() {
		PutDown();
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
