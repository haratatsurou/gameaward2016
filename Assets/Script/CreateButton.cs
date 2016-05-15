using UnityEngine;
using System.Collections;
using UniRx;
using System;
using UniRx.Triggers;
using UnityEngine.SceneManagement;
public class CreateButton : MonoBehaviour {
    public GameObject RainDrop;
    public int span;
    public IDisposable hoeg;
    //public string createpos = "upstart";


    public void Create(string createpos = "upstart" , float insposY = 0.1f) {
        hoeg = Observable.Timer(TimeSpan.FromSeconds(span) , TimeSpan.FromSeconds(2)).Subscribe(_ => {
            var createPos = GameObject.Find(createpos).transform;
            Vector3 inspos = new Vector3(createPos.position.x , createPos.position.y - insposY , createPos.position.z);
            Instantiate(RainDrop , inspos , Quaternion.identity);
        });


    }
    //初スタートするとき
    public void Create(string createpos = "upstart") {
        hoeg = Observable.Timer(TimeSpan.FromSeconds(span) , TimeSpan.FromSeconds(2)).Subscribe(_ => {
            var createPos = GameObject.Find(createpos).transform;
            Vector3 inspos = new Vector3(createPos.position.x , createPos.position.y - 0.1f , createPos.position.z);
            Instantiate(RainDrop , inspos , Quaternion.identity);
        });
        GameObject[] objs = GameObject.FindGameObjectsWithTag("road");
        foreach (GameObject obj in objs) {
            obj.GetComponent<operation>( ).colliders[1].isTrigger = false;

        }
    }

}
