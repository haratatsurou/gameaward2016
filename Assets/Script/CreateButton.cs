using UnityEngine;
using System.Collections;
using UniRx;
using System;
using UniRx.Triggers;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
public class CreateButton : MonoBehaviour {
    public static bool moveflag = false;
    public static bool colliderobject = false;
    private GameObject RainDrop;
    private int span;
    public IDisposable hoeg;
    [HideInInspector]
    public int i;
    private int Limit;
  //  private Button returnbutton;

    StageInfo manager;
    //private bool[] set;
    void Migration() {
        manager = StageManager.Instance.nowstage;
        Limit = manager.Limit;
        RainDrop = manager.Rain;
        span = manager.span;
    }
    void Start() {
        Migration( );
        
        //returnbutton = GameObject.Find("UI/Top/Return").GetComponent<Button>( );
    }
  public  void endINS() {
        var endins = this.UpdateAsObservable( )
            .Where(_ => Limit - 1 < i);//制限に達したら水玉を出すのをやメル
        endins
            .Subscribe(_ => {
                hoeg.Dispose( );
                //GameObject.Find("UI/Top/play").GetComponent<Button>( ).interactable = true;
                ////反転ボタンを押せるように
                //returnbutton.interactable = true;

            });
    }
    //帰り道用
    public void Create(float insposY=0.1f,string createpos = "upstart") {

        i = 0;
        var intohalfGoal = GameObject.Find("downgoal").GetComponent<halfGoal>( ).count;
        Limit = intohalfGoal;
        endINS( );
        //一定間隔で水玉を出す
        hoeg = Observable.Timer(TimeSpan.FromSeconds(span) , TimeSpan.FromSeconds(span)).Subscribe(_ => {
            var createPos = GameObject.Find(createpos).transform;
            Vector3 inspos = new Vector3(createPos.position.x , createPos.position.y -insposY , 0);
            Instantiate(RainDrop , inspos , Quaternion.identity);
            i++;
        });
        if ( createpos == "downstart" ) {
            GameObject.Find("downgoal").GetComponent<BoxCollider>( ).isTrigger = false;
        }
    }
    bool Match() {
        bool flag = false;
        for(int i=0 ;i<manager.setitem.Length ;i++ ) {
            if( manager.setitem[i].SET_ITEM_FLAG ) {
                flag= true;
            }else {
                flag= false;
            }
        }
        return flag;
    }
    public void ResetMatch() {
        for ( int i = 0 ; i < manager.setitem.Length ; i++ ) {
            manager.setitem[i].SET_ITEM_FLAG = false;
        }
    }
    //初スタートするとき
    public void Create(string createpos = "upstart") {
        i = 0;
        if (Match() ) {
            if ( !colliderobject ) {
                GameObject.Find("UI/Top/play").GetComponent<Button>( ).interactable = false;
                hoeg = Observable.Timer(TimeSpan.FromSeconds(span) , TimeSpan.FromSeconds(span)).Subscribe(_ => {
                    var createPos = GameObject.Find(createpos).transform;
                    Vector3 inspos = new Vector3(createPos.position.x , createPos.position.y - 0.1f , 0);
                    Instantiate(RainDrop , inspos , Quaternion.identity);
                   
                    moveflag = true;
                    GameObject.Find("Main Camera").GetComponent<ObservableUpdateTrigger>( ).enabled = false;
                    i++;
                });
                GameObject[] objs = GameObject.FindGameObjectsWithTag("road");
                
                foreach ( GameObject obj in objs ) {
                    obj.GetComponent<operation>( ).colliders[1].isTrigger = false;
                }
            } else {
                GameObject.Find("dialog").GetComponent<dialog>( ).display("オブジェクトが接触しているよ");
            }
        } else {
            GameObject.Find("dialog").GetComponent<dialog>( ).display("エラー置いてないオブジェクトがあるかもね");
        }
        
    }


}
