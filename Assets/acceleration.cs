using UnityEngine;
using System.Collections;

public class acceleration : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        Physics.gravity = new Vector3(Input.acceleration.x * 1.2f , Physics.gravity.y , Physics.gravity.z);
	}
}
