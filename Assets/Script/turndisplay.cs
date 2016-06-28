using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class turndisplay : MonoBehaviour {

    void OnEnable() {
        GameObject.Find("Main Camera").GetComponent<Animator>( ).enabled = false;
    }
    public void ChangeG() {

        Invoke("hoge" , 2.5f);
        GameObject.Find("Main Camera").GetComponent<Animator>( ).enabled = true;
        GameObject.Find("UI/Top/reset").GetComponent<Button>( ).interactable = false;
        DestroyRain( );
        this.GetComponent<acceleration>( ).i = -1f;
        GameObject.Find("upgoal").GetComponent<Goal>( ).GoalRain( );
    }
    void hoge() {
        Physics.gravity = -Physics.gravity;
        GameObject.Find("Main Camera").GetComponent<Animator>( ).enabled = false;
        try {
            //ジョインとの変更------------------------------------------------------------------------------------
            var underblock = GameObject.Find("underblock").GetComponent<HingeJoint>( );
            underblock.axis = new Vector3(0 , 0 , -90f);
            var topblock = GameObject.Find("topblock").GetComponent<HingeJoint>( );
            topblock.axis = new Vector3(0 , 0 , -90f);
            //-------------------------------------------------------------------------------------------------
        } catch ( NullReferenceException){

        }
        GameObject.Find("UI/Top/play").GetComponent<Button>( ).interactable = false;
        GameObject.Find("UI/Top/reset").GetComponent<Button>( ).interactable = true;
        var create = this.GetComponent<CreateButton>( );
        Dispose(create);
        CreateStart(create);

    }
    void DestroyRain() {
        foreach ( var rain in GameObject.FindGameObjectsWithTag("rain") ) {
            Destroy(rain);
        }
    }
    public void Dispose(CreateButton create) {
        try {
            create.hoeg.Dispose( );//一回購読停止する
        } catch ( NullReferenceException ) {

        }
    }
    public void CreateStart(CreateButton create) {
        create.Create( -0.5f, "downstart" );// 再びstart
    }

}
