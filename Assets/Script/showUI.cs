using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using System;
using UnityEngine.UI;
public class showUI : MonoBehaviour {
    private SetRotation findgameonj;
    void OnEnable() {
    }
    void Update() {
    }
    void frindbackGroud() {
        //var endtouchevent = this.UpdateAsObservable( ).Where(_ => Input.GetMouseButtonUp(0))
        //    .Select(canves => GameObject.Find("UI").GetComponent<Canvas>( ))
        //    .Subscribe(canves => {
        //        canves.enabled = true;
        //    });
        var touchevent = this.UpdateAsObservable( ).Where(_ => Input.GetMouseButtonDown(0))
            .Select(canves => GameObject.Find("UI").GetComponent<Canvas>( ))
            .Subscribe(canves => {
                    if ( canves.enabled ) {
                        canves.enabled = false;
                    } else {
                        canves.enabled = true;
                    }
            });
    }
}
