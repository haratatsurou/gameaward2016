using UnityEngine;
using System.Collections;

public class objkotei : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate() {
        this.transform.localRotation = new Quaternion(this.transform.localRotation.x
            , 90.00000f
            , this.transform.localRotation.z
            , this.transform.localRotation.w);
    }
}
