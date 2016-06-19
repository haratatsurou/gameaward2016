using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class turndisplay : MonoBehaviour {

    void Start() {

    }
    public void ChangeG() {
  
        Physics.gravity = -Physics.gravity;
        GameObject.Find("Main Camera").GetComponent<Transform>( ).Rotate(new Vector3(0 , 0 , 180f));

        //ジョインとの変更
        var underblock = GameObject.Find("underblock").GetComponent<HingeJoint>( ).axis = new Vector3(0 , 0 , -90f);
        var topblock = GameObject.Find("topblock").GetComponent<HingeJoint>( ).axis = new Vector3(0 , 0 , -90f);
        GameObject.Find("UI/Return").GetComponent<Button>( ).interactable = false;

        var create = this.GetComponent<CreateButton>( );
        Dispose(create);
        CreateStart(create);
    }
    public void Dispose(CreateButton create) {
        try {
            create.hoeg.Dispose( );//一回購読停止する
        } catch ( NullReferenceException ) { }
    }
    public void CreateStart(CreateButton create) {
        create.Create("downstart" , -0.1f);// 再びstart
    }

}
