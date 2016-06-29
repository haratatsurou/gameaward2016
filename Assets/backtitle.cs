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
        DeleateSaveData( );
    }
    void DeleateSaveData() {
        thisbutton.onClick.AsObservable( )
            .FirstOrDefault( )
            .Subscribe(_ => {
                AudioManager.Instance.PlaySE("openingSE");
                Destroy(GameObject.Find("Manager"));
                FadeManager.Instance.LoadLevel("StartMenu" , loadtime);
            });
    }
}
