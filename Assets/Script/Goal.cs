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


    //}
    void GoalRain()
    {
        var goal = this.OnTriggerEnterAsObservable()
            .Where(goaltag => goaltag.tag == "rain")
            .Subscribe(goaltag => {
                Destroy(goaltag.gameObject);
                var createPos = this.gameObject.transform;
                float n = 0.4f;
                if ( this.gameObject.name.Contains("up") ) {
                }
                if( this.gameObject.name.Contains("down") ) {
                    n = -n;
                }
                Vector3 inspos = new Vector3(createPos.position.x , createPos.position.y + n , createPos.position.z);
               var dummy=(GameObject)Instantiate(RainDrop , inspos , Quaternion.identity);
                var rigidbody = dummy.GetComponent<Rigidbody>( );
                float random = Random.Range(-10f , 5f);
               rigidbody.AddForce( random, 0 , 0,ForceMode.Force);
                rigidbody.mass = 0.1f;
                //goaltag.gameObject.transform.position = inspos;
            });
    }
}
