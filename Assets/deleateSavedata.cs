using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class deleateSavedata : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DeleateSaveData( );

    }
	void DeleateSaveData() {
        var deleate = this.UpdateAsObservable( )
            .Where(_ => Input.GetMouseButtonDown(0));
        deleate
            .Skip(19)
            .FirstOrDefault()
            .Subscribe(_ => {
                SaveManager.Instance.Reset( );
                AudioManager.Instance.PlaySE("decideSE");
                GameObject.Find("Canvas/Text").GetComponent<Text>( ).text = "セーブデータは削除されました。";
                Invoke("reset" , 5f);
            });
    }
    void reset() {
        GameObject.Find("Canvas/Text").GetComponent<Text>( ).text = "";
        DeleateSaveData( );
    }
}
