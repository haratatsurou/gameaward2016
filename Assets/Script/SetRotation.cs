using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System;
using UnityEngine.SceneManagement;

public class SetRotation : MonoBehaviour {
    public LayerMask mask;
    [SerializeField, Range(0.2f , 2f), Header("長押しした時間")]
    public float longTap;
    float rotatePos = 0;
    private Vector3? oldmousepos;
    void Awake() {
        LongTap( );
        SceneManager.LoadScene("SetUI" , LoadSceneMode.Additive);
    }
    void Start() { }

    public void LongTap() {
        GameObject obj = null;
        var getObj = false;
        //ゲームオブジェクト取得----------------------------------
        var serchOjb = this.UpdateAsObservable( )
            .Where(_ => Input.GetMouseButton(0))
            .Subscribe(_ => {
                try {
                    obj = DecisionObj( );
                    if ( obj.tag == "road" ) {
                        getObj = true;
                        if ( Input.GetMouseButtonDown(0) ) {
                            oldmousepos = new Vector3(Mathf.FloorToInt(Input.mousePosition.x) , Mathf.FloorToInt(Input.mousePosition.y));
                        }

                    } else {
                        getObj = false;
                        oldmousepos = null;

                    }
                } catch ( NullReferenceException ) {
                    getObj = false;
                }
            });
        //---------------------------------------------------
        ////ロングクリック----------------------------------------
        var mouseDownStream = this.UpdateAsObservable( ).Where(_ => Input.GetMouseButtonDown(0));
        var mouseUpStream = this.UpdateAsObservable( ).Where(_ => Input.GetMouseButtonUp(0));

        mouseDownStream
            //マウスクリックされたら3秒後にOnNextを流す
            .SelectMany(_ => Observable.Timer(TimeSpan.FromSeconds(longTap)))
            .Where(_ => getObj)//オブジェクトを取得
            .DistinctUntilChanged( )
            .ThrottleFrame(10)
            .Where(_ => CheckMove(Input.mousePosition))
             //途中でMouseUpされたらストリームをリセット
             .TakeUntil(mouseUpStream)
            //マウスの座標が変わってたらストリームをリセット
            .RepeatUntilDestroy(this.gameObject)
            .Subscribe(_ => {
                try {
                    CreateButton.moveflag = true;
                    ModeRotate(obj);
                    serchOjb.Dispose( );
                    getObj = false;
                    rotatePos = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
                } catch ( NullReferenceException ) {

                }
            });
        //長押しのキャンセル判定
        mouseDownStream.Timestamp( )
            .Zip(mouseUpStream.Timestamp( ) , (d , u) => ( u.Timestamp - d.Timestamp ).TotalMilliseconds / 1000.0f)
            .Where(time => time < longTap)
            .Subscribe(t => {
                //Debug.Log(t + "秒でキャンセル")
            });
        //dontmove
        //    .Subscribe(hoge => { print("asdf"); });
    }
    void ModeRotate(GameObject rotateObj) {

        var rotate = this.UpdateAsObservable( )
            .Where(_ => Input.GetMouseButton(0));
        rotate
            .TakeUntil(this.UpdateAsObservable( ).Where(_ => Input.GetMouseButtonUp(0)))
            .Subscribe(_ => {
                var hoge2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var result = hoge2.y - rotatePos;
                if ( rotateObj.transform.localPosition.x - hoge2.x > 0 ) {
                    result = -result;
                } else {
                }
                rotateObj.transform.Rotate(new Vector3(0 , 0 , result) , Space.World);

            });

        var stop = this.UpdateAsObservable( )
            .SkipUntil(rotate)
            .Where(_ => Input.GetMouseButtonUp(0))
            .FirstOrDefault( );
        stop
            .Subscribe(_ => {
                LongTap( );
                CreateButton.moveflag = false;
                rotatePos = 0;
            });

    }
    //指の座標が動いたか否かの判定
    bool CheckMove(Vector3 newmousepos) {
        newmousepos= new Vector3(Mathf.FloorToInt(newmousepos.x) , Mathf.FloorToInt(newmousepos.y));
        if ( oldmousepos == newmousepos ) {
            return true;
        } else {
            oldmousepos = null;
            return false;
        }
    }

    //触れたオブジェクトを返す
    GameObject DecisionObj() {
        RaycastHit hit;
        Ray ray = GetComponent<Camera>( ).ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray , out hit , mask.value);
        return hit.collider.gameObject;
    }

}
