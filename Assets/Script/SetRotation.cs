using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System;

public class SetRotation : MonoBehaviour {
    public LayerMask mask;
    void Start() { DoubleClick( ); }

    public void DoubleClick() {
        GameObject obj = null;
        var getObj = false;
        //ゲームオブジェクト取得
        var serchOjb = this.UpdateAsObservable( )
            .Where(_ => Input.GetMouseButton(0))
            .Subscribe(_ => {
                try {
                    obj = DecisionObj( );
                    getObj = true;
                } catch ( NullReferenceException ) {
                    getObj = false;
                }
            });

        var click = this.UpdateAsObservable( )
            .Where(_ => Input.GetMouseButtonDown(0) && getObj);
        click
            .Buffer(click.Throttle(TimeSpan.FromMilliseconds(200)))
            .Where(x => x.Count >= 2)
            .FirstOrDefault()
            .Subscribe(_ => {
                ModeRotate(obj);
                serchOjb.Dispose( );
                getObj = false;
                obj.GetComponent<operation>( ).moveflag = true;
            });
    }

    void ModeRotate(GameObject rotateObj) {
       
        var rotate = this.UpdateAsObservable( )
            .Where(_ => Input.GetMouseButton(0));
        rotate
            .TakeUntil(this.UpdateAsObservable().Where(_=>Input.GetMouseButtonUp(0)))
            .Subscribe(_ => {
                var hoge2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var rotatePos = hoge2.y;
                rotateObj.transform.Rotate(new Vector3(0 , 0 , rotatePos) , Space.World);

            });

        var stop = this.UpdateAsObservable( )
            .SkipUntil(rotate)
            .Where(_ => Input.GetMouseButtonUp(0))
            .FirstOrDefault( );
        stop
            .Subscribe(_ => {
                DoubleClick( );
                rotateObj.GetComponent<operation>( ).moveflag = false;
            });

    }

    //触れたオブジェクトを返す
    GameObject DecisionObj() {
        RaycastHit hit;
        Ray ray = GetComponent<Camera>( ).ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray , out hit , mask.value);
        return hit.collider.gameObject;
    }

}
