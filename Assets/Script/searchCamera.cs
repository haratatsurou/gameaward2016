using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class searchCamera : MonoBehaviour {

    void Awake() {
        var maincamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        var canvas = this.GetComponent<Canvas>( );
        canvas.worldCamera = maincamera;
        canvas.sortingOrder = 10;
    }
}
