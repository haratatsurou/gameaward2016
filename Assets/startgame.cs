using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class startgame : MonoBehaviour {
    private Button start;

	void Start () {
        OnStartGame( );
        start = GameObject.Find("Canvas/Button").GetComponent<Button>( );
	}
    void OnStartGame() {
        start.onClick.AsObservable()
            .FirstOrDefault()
            .Subscribe(hoge => { 
                FadeManager.Instance.LoadLevel("StageSelect" , 1.4f);
            });
    }
}
