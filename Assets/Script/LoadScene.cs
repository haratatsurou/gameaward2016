using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UniRx;
using System;
using UniRx.Triggers;
using System.Linq;
using System.Collections.Generic;

public class LoadScene : MonoBehaviour {
    public float loadtime = 1.4f;
    public Sprite clearimage;
    public Sprite defimage;
    public void Load(int loadnum = 0) {
        this.UpdateAsObservable( ).FirstOrDefault( ).Subscribe(_ => {
            FadeManager.Instance.LoadLevel("Stage" + loadnum.ToString( ) , loadtime);
            this.GetComponent<GraphicRaycaster>( ).enabled = false;
            AudioManager.Instance.PlaySE("decide");
        });
    }
    void Start() {

    }
    void ghoge() {
#if UNITY_EDITOR
        //SampleSaveData( );
#endif

    }
    void OnEnable() {
        saveload( );
        print("call");
        AudioManager.Instance.PlayBGM("soundofdesignOP");
    }
    private List<string> keys = new List<string>( );
    //セーブデータ全部ロード
    public void saveload() {
        List<GameObject> stars = new List<GameObject>( );
        keys = new List<string>(SaveManager.Instance.saveinfo.Keys);
        //セーブデータから星の画像を取得する-----------------------------------------------
        try {
            foreach ( var key in keys ) {  //ステージのキー検索
                var parent = GameObject.Find("Canvas/" + key).transform;
                stars = new List<GameObject>( );
                foreach ( Transform star in parent ) { //スター取得
                        //画像差し替える（Default画像）
                        star.gameObject.GetComponent<Image>( ).sprite = defimage;
                        stars.Add(star.gameObject);
                }

                Change(stars , key);

            }
        } catch ( KeyNotFoundException ) {
            print("ぷすす");
        } catch ( NullReferenceException ) {
            print("ステージなかったわ");
        }
        //--------------------------------------------------------------------------
    }
    void Change(List<GameObject> stars , string key) {
        int starnum = SaveManager.Instance.saveinfo[key].getstar;
        print("stageNmae=" + key + "starnum" + starnum);
        for ( int i = 0 ; i < starnum ; i++ ) {
            //クリアした画像にさしかえる
            stars[i].GetComponent<Image>( ).sprite = clearimage;
        }
    }
//#if UNITY_EDITOR
//    void SampleSaveData() {
//        info hoge = new info( );
//        hoge.getstar = (int)UnityEngine.Random.Range(0 , 4);
//        hoge.clear = Convert.ToBoolean((int)UnityEngine.Random.Range(0 , 1));
//        try {

//            for ( int i = 1 ; i < 4 ; i++ ) {
//                SaveManager.Instance.saveinfo.Add("Stage" + i.ToString( ) , hoge);
//            }
//        } catch ( ArgumentException ) {
//            for ( int i = 1 ; i < 4 ; i++ ) {
//                SaveManager.Instance.saveinfo["Stage" + i.ToString( )] = hoge;
//            }
//        }
//    }
//    void OnDisable() {
//        SaveManager.Instance.Reset( );
//    }
//#endif

}
