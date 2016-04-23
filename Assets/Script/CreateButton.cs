using UnityEngine;
using System.Collections;
using UniRx;
using System;
using UniRx.Triggers;
public class CreateButton : MonoBehaviour {
    public GameObject RainDrop;
    public int span;
    public string createpos="upstart";
    void Start() {
        //span秒後にintervalの間を開けてCreate()を実行
        Observable.Timer(TimeSpan.FromSeconds(span) , TimeSpan.FromSeconds(2)).Subscribe(_ => {
            Create( );
        });
        Invoke("ChangeG" , 30f);
    }
    void ChangeG() {
        Physics.gravity = new Vector3(0 , 9.8f , 0);
        GameObject.Find("Main Camera").GetComponent<Transform>( ).Rotate(new Vector3(0 , 0 , 180f));
    }

    void Update() {

    }
    public void Create() {
        var createPos = GameObject.Find(createpos).transform;
        Vector3 inspos = new Vector3(createPos.position.x , createPos.position.y-0.1f , createPos.position.z);
        Instantiate(RainDrop , inspos , Quaternion.identity);
    }
}
