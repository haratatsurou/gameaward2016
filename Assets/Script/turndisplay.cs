using UnityEngine;
using System.Collections;

public class turndisplay : MonoBehaviour {

    void Start() {

    }
    public void ChangeG() {
        Physics.gravity = -Physics.gravity;
        GameObject.Find("Main Camera").GetComponent<Transform>( ).Rotate(new Vector3(0 , 0 , 180f));

        //ジョインとの変更
        var underblock = GameObject.Find("underblock").GetComponent<HingeJoint>( ).axis = new Vector3(0 , 0 , -90f);
        var topblock = GameObject.Find("topblock").GetComponent<HingeJoint>( ).axis = new Vector3(0 , 0 , -90f);

        var create = this.GetComponent<CreateButton>( );
        create.hoeg.Dispose( );//一回購読停止する
        create.Create("downstart" , -0.1f);// 再びstart

    }
    void Update() {

    }
}
