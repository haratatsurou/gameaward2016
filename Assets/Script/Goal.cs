using UnityEngine;
using System.Collections;
using UniRx;
using UnityEngine.UI;
using UniRx.Triggers;
using System;
//くそコード
public class Goal : MonoBehaviour {
    private GameObject RainDrop;
    private Text count;
    private clearmessage clear;
    void Start() {
        //CountGoal();
        RainDrop = StageManager.Instance.nowstage.Rain;
       clear =GameObject.Find("clear").GetComponent<clearmessage>( );

    }
    IDisposable goal;
    void CountGoal() {
        goal= this.OnTriggerEnterAsObservable( )
            .Where(goaltag => goaltag.tag == "rain")
            .Buffer(StageManager.Instance.nowstage.UnLimit-1)
            .FirstOrDefault( )
            .Subscribe(_ => {
                StageClear( );
            }).AddTo(gameObject);
    }
    void StageClear() {
        goal.Dispose( );
        clear.displaytext();
    }
   
   public void GoalRain()
    {
        var goal = this.OnTriggerEnterAsObservable()
            .Where(goaltag => goaltag.tag == "rain")
            .Subscribe(goaltag => {
                AudioManager.Instance.PlaySE("decide");
                StartCoroutine("destroyobj",goaltag.gameObject);
                CountGoal( );
            }).AddTo(this.gameObject);
    }

    IEnumerator destroyobj(GameObject destroy) {
        yield return new WaitForSeconds(0.1f);
        this.UpdateAsObservable( )
            .Subscribe(_ => {
                var time = Time.deltaTime;
                destroy.transform.localScale -= new Vector3(time , time , time);

                if ( destroy.transform.localScale.y < 0 ) {
                    Destroy(destroy);
                    float n = 0.4f;
                    var createPos = this.gameObject.transform;

                    if ( this.gameObject.name.Contains("up") ) {
                        n = 1;
                    }
                    if ( this.gameObject.name.Contains("down") ) {
                        n = -n;
                    }
                    InstancedummyObj(createPos , n);
                }
            })
            .AddTo(destroy);
    }
    //プールにオブジェクトを生成する
    void InstancedummyObj(Transform createPos,float n) {

        Vector3 inspos = new Vector3(createPos.position.x , createPos.position.y + n , createPos.position.z);
        var dummy = (GameObject)Instantiate(RainDrop , inspos , Quaternion.identity);
        dummy.tag = "otherrain";

        var rigidbody = dummy.GetComponent<Rigidbody>( );
        float random = UnityEngine.Random.Range(-17f , 5f);
        rigidbody.AddForce(random , 0 , 0 );
        dummy.GetComponent<SphereCollider>( ).radius = 0.1f;
        rigidbody.mass = 0.1f;
    }
}
