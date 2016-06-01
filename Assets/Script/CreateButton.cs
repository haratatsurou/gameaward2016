using UnityEngine;
using System.Collections;
using UniRx;
using System;
using UniRx.Triggers;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CreateButton : MonoBehaviour {
    public GameObject RainDrop;
    public int span;
    public IDisposable hoeg;
    int i;
    [Header("作り出すオブジェクトの個数")]
    public int Limit;
    private Button returnbutton;

    //public string createpos = "upstart";
    void Start() {
        returnbutton = GameObject.Find("UI/Return").GetComponent<Button>( );
        var endins = this.UpdateAsObservable( )
            .Where(_ => Limit < i);
        endins
            .Subscribe(_ => {
                hoeg.Dispose( );
                returnbutton.interactable = true;

            });
    }

    public void Create(string createpos = "upstart" , float insposY = 0.1f) {
        hoeg = Observable.Timer(TimeSpan.FromSeconds(span) , TimeSpan.FromSeconds(2)).Subscribe(_ => {
            var createPos = GameObject.Find(createpos).transform;
            Vector3 inspos = new Vector3(createPos.position.x , createPos.position.y - insposY , createPos.position.z);
            Instantiate(RainDrop , inspos , Quaternion.identity);
            i++;
        });




    }
    //初スタートするとき
    public void Create(string createpos = "upstart") {
        hoeg = Observable.Timer(TimeSpan.FromSeconds(span) , TimeSpan.FromSeconds(2)).Subscribe(_ => {
            var createPos = GameObject.Find(createpos).transform;
            Vector3 inspos = new Vector3(createPos.position.x , createPos.position.y - 0.1f , createPos.position.z);
            Instantiate(RainDrop , inspos , Quaternion.identity);
            i++;
        });
        GameObject[] objs = GameObject.FindGameObjectsWithTag("road");
        foreach ( GameObject obj in objs ) {
            obj.GetComponent<operation>( ).colliders[1].isTrigger = false;

        }
    }

}
