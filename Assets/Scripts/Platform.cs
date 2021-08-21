using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] Sprite platformOn;
    [SerializeField] Sprite platformOff;
    [SerializeField] bool state;
    // Start is called before the first frame update
    void Start() {
        Swap();
    }
    public void PlatformOn () {
        foreach (Transform t in gameObject.transform) {
            t.gameObject.GetComponent<SpriteRenderer>().sprite = platformOn;
            t.gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }
    public void PlatformOff() {
        foreach (Transform t in gameObject.transform) {
            t.gameObject.GetComponent<SpriteRenderer>().sprite = platformOff;
            t.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    public void Swap() {
        state = !state;
        if (state) {
            PlatformOn();
        } else {
            PlatformOff();
        }
    }
}
