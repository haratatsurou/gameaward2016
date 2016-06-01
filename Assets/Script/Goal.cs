using UnityEngine;
using System.Collections;
using UniRx;
using UnityEngine.UI;
using UniRx.Triggers;

public class Goal : MonoBehaviour
{
    public GameObject RainDrop;
    private Text count;
    void Start()
    {
        //CountGoal();
        GoalRain();
    }
    //void CountGoal()
    //{
    //    var goal = this.OnTriggerEnterAsObservable()
    //        .Where(goaltag => goaltag.tag == "rain");
    //    goal
    //        .Buffer(n)
    //        .FirstOrDefault()
    //        .Subscribe(_ => { print("終わり"); });


   
    void GoalRain()
    {
        var goal = this.OnTriggerEnterAsObservable()
            .Where(goaltag => goaltag.tag == "rain")
            .Subscribe(goaltag => {
                // Destroy(goaltag.gameObject);
                StartCoroutine("destroyobj",goaltag.gameObject);
                
                //goaltag.gameObject.transform.position = inspos;
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
                    //}
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
    void InstancedummyObj(Transform createPos,float n) {
        
        Vector3 inspos = new Vector3(createPos.position.x , createPos.position.y + n , createPos.position.z);
        var dummy = (GameObject)Instantiate(RainDrop , inspos , Quaternion.identity);
        var rigidbody = dummy.GetComponent<Rigidbody>( );
        float random = Random.Range(-10f , 5f);
        rigidbody.AddForce(random , 0 , 0 , ForceMode.Force);
        rigidbody.mass = 0.1f;
    }
}
