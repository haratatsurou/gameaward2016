using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class returngame : MonoBehaviour {
    private Button button;
    public float loadtime;
    void Start() {
        button = this.GetComponent<Button>( );
        Invoke("returngames" , loadtime + 1f);
        
    }
    void returngames() {
#if UNITY_EDIOTR
        print("ゲームスタートOK");
#endif
        button.onClick.AsObservable( )
            .FirstOrDefault( )
            .Subscribe(_ => {
               FadeManager.Instance.LoadLevel("StageSelect", loadtime);
                AudioManager.Instance.PlaySE("openingSE");
           });
    }
}
