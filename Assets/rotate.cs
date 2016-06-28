using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

public class rotate : MonoBehaviour {
    public int direction = 1;
    public void rotatehusya() {
        this.UpdateAsObservable( ).
             Subscribe(_ => {
                 var time = Time.deltaTime;
                 transform.Rotate(0 , 0 , direction*time * 50 , Space.World);
             });
    } 
}
