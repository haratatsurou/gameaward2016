using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System;
using UnityEngine.SceneManagement;

public class SetRotation : MonoBehaviour {
    public LayerMask mask;
    void Awake() {
        DoubleClick( );
        SceneManager.LoadScene("SetUI" , LoadSceneMode.Additive);
    }
    void Start() { }

    public void DoubleClick() {
        GameObject obj = null;
        var getObj = false;
            //ゲームオブジェクト取得
            var serchOjb = this.UpdateAsObservable( )
                .Where(_ => Input.GetMouseButton(0))
                .Subscribe(_ => {
                    try {
                        obj = DecisionObj( );
                        if ( obj.tag == "road" ) {
                            getObj = true;
                        }else {
                            getObj = false;
                        }
                        } catch ( NullReferenceException ) {
                        getObj = false;
                    }
                });

            var click = this.UpdateAsObservable( )
                .Where(_ => Input.GetMouseButtonDown(0) && getObj);
            click
                .Buffer(click.Throttle(TimeSpan.FromMilliseconds(150)))
                .Where(x => x.Count >= 2)
                .FirstOrDefault( )
                .Subscribe(_ => {
                    try {
                        CreateButton.moveflag = true;
                    //obj.GetComponent<operation>( ).moveflag = true;
                    ModeRotate(obj);
                        serchOjb.Dispose( );

                        getObj = false;
                        rotatePos = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
                    } catch ( NullReferenceException ) {

                    }
                });
    }
    float rotatePos = 0;
    void ModeRotate(GameObject rotateObj) {
        
        var rotate = this.UpdateAsObservable( )
            .Where(_ => Input.GetMouseButton(0));
        rotate
            .TakeUntil(this.UpdateAsObservable( ).Where(_ => Input.GetMouseButtonUp(0)))
            .Subscribe(_ => {
                var hoge2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var result = hoge2.y - rotatePos;
                rotateObj.transform.Rotate(new Vector3(0 , 0 , result) , Space.World);

            });

        var stop = this.UpdateAsObservable( )
            .SkipUntil(rotate)
            .Where(_ => Input.GetMouseButtonUp(0))
            .FirstOrDefault( );
        stop
            .Subscribe(_ => {
                DoubleClick( );
                CreateButton.moveflag = false;
                //rotateObj.GetComponent<operation>( ).moveflag = false;
                rotatePos = 0;
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
