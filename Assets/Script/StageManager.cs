using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System;
[System.Serializable]
public struct StageInfo {
    [Header("UI関連")]
    public string Reset_Scene_Name;
    public string Next_Scene_Name;
    [Header("設置するオブジェクト")]
    public setItem[] setitem;
    [Header("生成する雫")]
    public GameObject Rain;
    [Header("オブジェクトが出てくる感覚(個/sec)")]
    public int span;
    [Header("作り出す雫の数")]
    public int Limit;
    [Header("ゴールの条件(雫の個数)")]
    public int UnLimit;
    [Header("取得した星の数")]
    public int GetStar;
}
[System.Serializable]
public struct setItem {
    public GameObject obj;
    public Sprite objImage;
    public bool SET_ITEM_FLAG;

}

public class StageManager : SingletonMonoBehaviour<StageManager> {
    [Header("各ステージに関する詳細情報")]
    public StageInfo[] stageinfo;
    [HideInInspector]
    public StageInfo nowstage;

    public float worldTime;
    public int oldstar;
    void Awake() {
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //自動でスリープ入るのを無効にする
        // nowstage = stageinfo[NowtheStage( )];
        //Time.timeScale = worldTime;
        //oldstar = StageManager.Instance.nowstage.GetStar;
    }
    public int NowtheStage() {
        Regex rex = new Regex(@"[^0-9]"); //数字のみ
        int result = int.Parse(rex.Replace(SceneManager.GetActiveScene( ).name , ""));
        return result - 1;
    }
    public void ClearInfo() {
        //クリア情報----------------------------------------------------------
        SaveManager.Instance.clearinfo.clear = true;
        SaveManager.Instance.clearinfo.getstar = highSCORE(StageManager.Instance.nowstage.GetStar);
        //------------------------------------------------------------------

        var Reset_Scene_Name = StageManager.Instance.nowstage.Reset_Scene_Name;
        var clearinfo= SaveManager.Instance.clearinfo;
        try {
            SaveManager.Instance.saveinfo.Add(Reset_Scene_Name ,clearinfo);
        } catch ( ArgumentException ) {//すでにキーがあるとき
            SaveManager.Instance.saveinfo[Reset_Scene_Name] = SaveManager.Instance.clearinfo;
        }
#if UNITY_ANDROID
        //セーブ処理
        SaveManager.Instance.Save( );
#endif
    }
    //スコア更新するか否か
    int highSCORE(int star) {
        return Mathf.Max(oldstar , star);
    }
    void Update() {
        if ( Application.platform == RuntimePlatform.Android &&
    ( Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu) ) ) {
            Application.Quit( );
        }
    }
}
