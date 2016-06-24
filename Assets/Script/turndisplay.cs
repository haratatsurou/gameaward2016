using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class turndisplay : MonoBehaviour {

    void Start() {
        GameObject.Find("Main Camera").GetComponent<Animator>( ).enabled = false;
    }
    public void ChangeG() {

        Invoke("hoge" , 2.5f);
        GameObject.Find("Main Camera").GetComponent<Animator>( ).enabled = true;
        //GameObject.Find("Main Camera").GetComponent<Transform>( ).Rotate(new Vector3(0 , 0 , 180f));
        GameObject.Find("UI/reset").GetComponent<Button>( ).interactable = false;
        DestroyRain( );
        this.GetComponent<acceleration>( ).i = -1f;
    }
    void hoge() {

        Physics.gravity = -Physics.gravity;
        GameObject.Find("Main Camera").GetComponent<Animator>( ).enabled = false;
        //ジョインとの変更------------------------------------------------------------------------------------
        var underblock = GameObject.Find("underblock").GetComponent<HingeJoint>( );
        underblock.axis = new Vector3(0 , 0 , -90f);
        underblock.anchor = new Vector3(underblock.anchor.x , -underblock.anchor.y , underblock.anchor.z);
        var topblock = GameObject.Find("topblock").GetComponent<HingeJoint>( );
        topblock.axis= new Vector3(0 , 0 , -90f);
        topblock.anchor = new Vector3(topblock.anchor.x , -topblock.anchor.y , topblock.anchor.z);
        //-------------------------------------------------------------------------------------------------
        GameObject.Find("UI/Return").GetComponent<Button>( ).interactable = false;
        GameObject.Find("UI/reset").GetComponent<Button>( ).interactable = true;
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
        create.Create("downstart" , -0.1f);// 再びstart
    }

}
