using UnityEngine;

class Spikes : MonoBehaviour {
	
	[SerializeField] GameObject[] pops;
	int index;
	
	[SerializeField] AudioSource source;
	[SerializeField] AudioClip[] sounds;
	
	void OnTriggerEnter2D(Collider2D collider) {
		if (!Synchronizer.Self.isPlay) return;
		pops[index].transform.position = collider.transform.position;
		pops[index].SetActive(true);
		index = (index + 1) % pops.Length;
		collider.transform.position = Vector3.down * 868031011794f;
		source.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
	}
}
