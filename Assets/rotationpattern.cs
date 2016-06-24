using UnityEngine;
using System.Collections;

public class rotationpattern : MonoBehaviour {
    private float rot;
    private float newrote;
    private bool flag;
	// Use this for initialization
	void Start () {
        rot = 0;
        newrote = 90;
        flag = false;
	}
	
	// Update is called once per frame
	void Update () {
        if ( flag ) {
            newrote++;
            transform.rotation = Quaternion.Slerp(transform.rotation , Quaternion.Euler(0 , 0 , newrote) , Time.deltaTime * rot);
        }
	}
    void OnTriggerEnter(Collider rain) {
        if ( rain.tag == "rain" ) {
            rot += 0.1f;
            flag = true;
        }
    }
}
