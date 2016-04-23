using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class searchCamera : MonoBehaviour {

    void OnEnable() {
        var maincamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        var canvas = this.GetComponent<Canvas>( );

        canvas.worldCamera = maincamera;
        canvas.sortingOrder = 10;
    }

}
