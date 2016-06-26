using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using System;

public class speed : MonoBehaviour {
    private Button speedbutton;
    public Sprite image1, iamge2;
    void Start() {
        speedbutton = GameObject.Find("UI/Top/speed").GetComponent<Button>();
        speedbutton.onClick.AsObservable( )
           .Subscribe(_ => {
               if ( Time.timeScale == 1 ) {
                   StageManager.Instance.worldTime= 2;
                   Time.timeScale = StageManager.Instance.worldTime;
               }
               else if ( Time.timeScale == 2 ) {
                   StageManager.Instance.worldTime = 1;
                   Time.timeScale = StageManager.Instance.worldTime;
               } else {
               }

           });
    }
}
