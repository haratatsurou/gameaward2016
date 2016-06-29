using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class deleateSavedata : MonoBehaviour {
    private Text hoge;
	// Use this for initialization
	void OnEnable () {
        hoge = GameObject.Find("Canvas/Text").GetComponent<Text>( );
        DeleateSaveData( );

    }
    void DeleateSaveData() {
        var deleate = this.UpdateAsObservable( )
            .Where(_ => Input.GetMouseButtonDown(0)).Skip(19);
        deleate
            
            .Subscribe(_ => {
                SaveManager.Instance.Reset( );
                AudioManager.Instance.PlaySE("decideSE");
                hoge.text = "セーブデータは削除されました。";
                //Invoke("reset" , 5f);
            }).AddTo(this.gameObject);
    }
    void reset() {
        GameObject.Find("Canvas/Text").GetComponent<Text>( ).text = "";
        DeleateSaveData( );
    }
}
