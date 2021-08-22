using UnityEngine;

class Sounder : MonoBehaviour {
	
	[SerializeField] AudioSource source;
	[SerializeField] AudioClip[] clips;
	
	public void Activate() {
		source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
	}
	
}
