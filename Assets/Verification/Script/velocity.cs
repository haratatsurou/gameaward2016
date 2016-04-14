using UnityEngine;
using System.Collections;

public class velocity : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}
    void OnTriggerEnter(Collider ball)
    {
        var velocity = ball.GetComponent<Rigidbody>().velocity;
        var speed = Mathf.Abs(velocity.x + velocity.y);
        //print("速さ＝" +speed);
    }
}
