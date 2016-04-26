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
    void Start() {
        Create( );
        SceneManager.LoadScene("SetUI" , LoadSceneMode.Additive);
    }

    public void Create(string createpos = "upstart",float insposY=0.1f) {
        //span秒後にintervalの間を開けてCreate()を実行
       hoeg= Observable.Timer(TimeSpan.FromSeconds(span) , TimeSpan.FromSeconds(2)).Subscribe(_ => {
            var createPos = GameObject.Find(createpos).transform;
            Vector3 inspos = new Vector3(createPos.position.x , createPos.position.y - insposY , createPos.position.z);
            Instantiate(RainDrop , inspos , Quaternion.identity);
        });

    }
}
