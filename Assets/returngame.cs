using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class returngame : MonoBehaviour {
    private Button button;
    public float loadtime;
    public IObservable<Unit> a;
    void Start() {
        button = this.GetComponent<Button>( );
        Invoke("returngames" , loadtime + 1f);
#if UNITY_EDIOTR
        print("ゲームスタートOK");
           SaveManager.Instance.Reset( );
#endif


    }
    void returngames() {
#if UNITY_EDIOTR
        print("ゲームスタートOK");
#endif
         a = button.onClick.AsObservable( );
        a
            .FirstOrDefault( )
            .Subscribe(_ => {
                FadeManager.Instance.LoadLevel("StageSelect" , loadtime);
                AudioManager.Instance.PlaySE("openingSE");
            });
    }
}
