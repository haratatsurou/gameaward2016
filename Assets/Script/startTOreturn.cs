using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using System;

public class startTOreturn : MonoBehaviour {
    private Button startbutton;
    private Text text;
    private Image image;
    private string directory = "UI/Top/";
    public Sprite returnImage, startImage;
    private IObservable<Unit> clickbutton;
    void OnEnable() {
       var button = GameObject.Find(directory + "play");
        startbutton =button.GetComponent<Button>( );
        image = button.GetComponent<Image>( );
        image.sprite = startImage;
        Return_Start( );
    }
    public void Start_Return() {
        //見てくれ変更
        changeVisible(returnImage , "反転");
        startbutton.onClick.RemoveAllListeners( );
        startbutton.onClick.AsObservable( )
           .Subscribe(_ => {
               //ロジック変更
               this.GetComponent<turndisplay>( ).ChangeG( );

           });
    }
    //リセット用
    public void Return_Start() {
        changeVisible(startImage , "play");
        startbutton.onClick.RemoveAllListeners( );
        startbutton.onClick.AsObservable( )
            .Subscribe(_ => {
                this.GetComponent<CreateButton>( ).Create("upstart");
                
                
            });
    }
    void changeVisible(Sprite iconimage,string content) {
        image.sprite = iconimage;

    }
}
