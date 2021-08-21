using UnityEngine;

class ReverserRotator : MonoBehaviour {
	
	[SerializeField] Reverser reverser;
	
	void FixedUpdate() {
		transform.rotation = Quaternion.AngleAxis(transform.rotation.eulerAngles.z + reverser.newSpeed * Time.deltaTime, Vector3.forward);
	}
}
