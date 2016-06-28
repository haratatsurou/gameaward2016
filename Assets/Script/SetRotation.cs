using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System;
using UnityEngine.SceneManagement;

public class SetRotation : MonoBehaviour {
    public LayerMask mask;
    [ Header("長押しした時間")]
    public float longTap=0.3f;
    float rotatePos = 0;
    private Vector3? oldmousepos;

    private SpriteRenderer selectbak;
    void Awake() {

        LongTap( );
        if ( !SceneManager.GetSceneByName("SetUI").isLoaded ) {
            SceneManager.LoadScene("SetUI" , LoadSceneMode.Additive);
        }
    }
    void OnEnable() {
        selectbak = GameObject.Find("selectback").GetComponent<SpriteRenderer>( );
        selectbak.color = new Color(0 , 0 , 0 , 0);
    }

    void Update() {
    }
    public void LongTap() {
        GameObject obj = null;
        var getObj = false;
        //ゲームオブジェクト取得----------------------------------
        var serchOjb = this.UpdateAsObservable( )
            .Where(_ => Input.GetMouseButton(0))
            .Subscribe(_ => {
                try {
                    obj = DecisionObj();
                    if ( obj.tag == "road" ) {
                        getObj = true;
                        if ( Input.GetMouseButtonDown(0) ) {
                            oldmousepos = RoundPos(Input.mousePosition);
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
            //マウスクリックされたらlongTap秒後にOnNextを流す
            .SelectMany(_ => Observable.Timer(TimeSpan.FromSeconds(longTap)))
            .Where(_ => getObj)//オブジェクトを取得
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
        AudioManager.Instance.PlaySE("decide");
        rotateObj.GetComponent<sortLayer>( ).LayerName = "Forward";
        selectbak.color = new Color(0 , 0 , 0,0.5f);
        var rotate = this.UpdateAsObservable( )
            .Where(_ => Input.GetMouseButton(0));
        rotate
            .TakeUntil(this.UpdateAsObservable( ).Where(_ => Input.GetMouseButtonUp(0)))
            .Subscribe(_ => {
                var hoge2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var hoge1 = transform.InverseTransformPoint(hoge2);
                var y = hoge2.y - rotateObj.transform.localPosition.y;
                //   var x= hoge2.x - rotateObj.transform.position.x;
                if ( rotateObj.transform.localPosition.x - hoge2.x > 0 ) {

                    y = -y;
                }
                rotateObj.transform.Rotate(new Vector3(0 , 0 , y) , Space.World);

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

                rotateObj.GetComponent<sortLayer>( ).LayerName = "Default";
                selectbak.color = new Color(0 , 0 , 0 , 0);
            });

    }
    //指の座標が動いたか否かの判定
    bool CheckMove(Vector3 newmousepos) {
        newmousepos=RoundPos(newmousepos);
        if ( oldmousepos == newmousepos ) {
            return true;
        } else {
            oldmousepos = null;
            return false;
        }
    }

    //触れたオブジェクトを返す
  public  GameObject DecisionObj() {
        RaycastHit hit;
        Ray ray = GameObject.Find("Main Camera").GetComponent<Camera>( ).ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray , out hit , mask.value);
        return hit.collider.gameObject;
    }

    //1の桁を丸める
    Vector3 RoundPos(Vector3 pos) {
        pos.x = Mathf.Round(pos.x / 10);
        pos.y = Mathf.Round(pos.y / 10);

      return  new Vector3(pos.x * 10 , pos.y * 10 , 0);
    }

}
