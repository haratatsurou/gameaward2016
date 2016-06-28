using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System;

public class remainsrain : MonoBehaviour {
    private Color raincolor;
    private info stageinfo;
    private Text text;
    private Image rainimage;
    IObservable<Unit> before;
    void OnEnable() {
        var directory = "UI/Top/";
        text = GameObject.Find(directory + "num").GetComponent<Text>( );
        rainimage = GameObject.Find(directory + "rain").GetComponent<Image>( );
        raincolor = StageManager.Instance.nowstage.Rain.GetComponent<ParticleSystem>( ).startColor;
        rainimage.color = raincolor;
        startnum( );
    }
    public void startnum() {
        var turndisplaynum = GameObject.Find("system").GetComponent<CreateButton>( );
        text.text = "×" + turndisplaynum.rementionnum;
        before = this.UpdateAsObservable( );
        before
            .Subscribe(_ => {
                text.text = "×" + turndisplaynum.rementionnum;
            });
    }

}
