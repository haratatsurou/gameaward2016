using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class searchCamera : MonoBehaviour {
    void OnEnable() {
        var maincamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        var canvas = this.GetComponent<Canvas>( );
        canvas.worldCamera = maincamera;
        canvas.sortingOrder = 10;
    }
}
