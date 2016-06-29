using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
public class backtitle : MonoBehaviour {
    Button thisbutton;
    public float loadtime;
    void Start() {
        thisbutton = this.GetComponent<Button>( ); 

    }
    void DeleateSaveData() {
        thisbutton.onClick.AsObservable( )
            .FirstOrDefault( )
            .Subscribe(_ => {
                FadeManager.Instance.LoadLevel("StartMenu" , loadtime);
                AudioManager.Instance.PlaySE("openingSE");
            });
    }
}
