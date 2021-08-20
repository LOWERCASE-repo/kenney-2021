using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    [Header("Touch me")] 
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    int tileNum;

    Transform parent;
    [SerializeField]
    Image image;

    private int tileNumHide;

    private void Awake() {
        tileNumHide = tileNum;
        parent = Synchronizer.Self.playerPieces;
    }
    private void OnEnable() {
        Sprite s = prefab.GetComponent<SpriteRenderer>().sprite;
        image.sprite = s;
    }

    private void OnDisable() {
        tileNumHide = tileNum;
    }

    public void Generate () {
        Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);
        GameObject g = Instantiate(prefab, mousePos, Quaternion.identity, parent);
        Draggable drag = g.AddComponent<Draggable>();
        drag.PickUp();
        tileNumHide--;
    }
}
