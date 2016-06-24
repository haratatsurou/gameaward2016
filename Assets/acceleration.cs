using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

public class acceleration : MonoBehaviour {
    // Update is called once per frame
    Transform maincamera;
    public IObservable<Unit> gyrorotation;
    public float i =1f;

    void Start() {
        i = 1f;
        maincamera = GameObject.Find("Main Camera").GetComponent<Transform>( );
        Input.gyro.enabled = true;
        //Invoke("Turn" , 3f);
    }
    void Update() {

        //Quaternion gyro = Input.gyro.attitude;
        Physics.gravity = new Vector3(i * Input.gyro.gravity.x , Physics.gravity.y , Physics.gravity.z);
        //maincamera.localRotation = Quaternion.Euler(0 , 0 , 270)*( new Quaternion(0 , 0 , gyro.z , gyro.w) );
        //print(maincamera.localRotation);

    }
    //public void Turn() {
    //    Input.gyro.enabled = false; Input.gyro.enabled = true;
    //    gyrorotation = this.UpdateAsObservable( ).Where(cameraRotate => maincamera.localRotation.z > 60);
    //    this.UpdateAsObservable( ).TakeUntil(gyrorotation).Subscribe(_ => {
    //        Quaternion gyro = Input.gyro.attitude;
    //        maincamera.localRotation = Quaternion.Euler(0 , 0 , 90) * ( new Quaternion(0 , 0 , gyro.z , gyro.w) );
    //    });
    //}

}
