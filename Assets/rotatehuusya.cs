using UnityEngine;
using System.Collections;

public class rotatehuusya : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var time = Time.deltaTime;
        transform.Rotate( 0 , 0,time*50,Space.World );
	}
}
