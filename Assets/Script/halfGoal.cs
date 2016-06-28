using UnityEngine;
using System.Collections;
using UniRx;
using UnityEngine.UI;
using UniRx.Triggers;
using System;
using UnityEngine.SceneManagement;
public class halfGoal : MonoBehaviour {
    private GameObject RainDrop;
    public int count;
    private Button @return;

    private Goal goalobj;
    void Start() {
        //CountGoal();
      
        @return = GameObject.Find("UI/Top/play").GetComponent<Button>( ); //リターンカウント
        RainDrop = StageManager.Instance.nowstage.Rain;
        goalobj = GameObject.Find("upgoal").GetComponent<Goal>( );
        GoalRain( );
    }
    void CountGoal() {
        var goal = this.OnTriggerEnterAsObservable( )
            .Where(goaltag => goaltag.tag == "rain");
        goal
            .Buffer(StageManager.Instance.nowstage.UnLimit - 1)
            .FirstOrDefault( )
            .Subscribe(_ => {
                
                try {
                    @return.interactable = true; //反転できるように
                    GameObject.Find("system").GetComponent<startTOreturn>( ).Start_Return( ); //ボタンを変更する
                } catch ( NullReferenceException ) {
         
                }catch ( MissingReferenceException ) {

                    @return.interactable = true; //反転できるように
                }

            }).AddTo(this.gameObject);
    }
    void GoalRain() {
        count = 0;

        var goal = this.OnTriggerEnterAsObservable( )
            .Where(goaltag => goaltag.tag == "rain")
            .Subscribe(goaltag => {
                AudioManager.Instance.PlaySE("decide");
                StartCoroutine("destroyobj" , goaltag.gameObject);
                CountGoal( );
                count++;
            });
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
    void InstancedummyObj(Transform createPos , float n) {

        Vector3 inspos = new Vector3(createPos.position.x , createPos.position.y + n , createPos.position.z);

        var dummy = (GameObject)Instantiate(RainDrop , inspos , Quaternion.identity);
        dummy.tag = "otherrain";
        var rigidbody = dummy.GetComponent<Rigidbody>( );
        float random = UnityEngine.Random.Range(-17f , 7f);
        rigidbody.AddForce(random , 0 , 0);
        dummy.GetComponent<SphereCollider>( ).radius = 0.1f;
        rigidbody.mass = 0.1f;
    }
}
