using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System.Text.RegularExpressions;
[System.Serializable]
public struct StageInfo {
    [Header("UI関連")]
    public string Reset_Scene_Name;
    public string Next_Scene_Name;
    public string Dialog_Help_Message;
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
    [Header("ゴールしたか")]
    public bool Clear;
    [Header("取得した星の数")]
    public int GetStar;

}
[System.Serializable]
public struct setItem {
    public GameObject obj;
    public bool SET_ITEM_FLAG;

}

public class StageManager : SingletonMonoBehaviour<StageManager> {
    [Header("各ステージに関する詳細情報")]
    public StageInfo[] stageinfo;
    [HideInInspector]
    public StageInfo nowstage;

    public float worldTime;

    void Awake() {
        nowstage = stageinfo[NowtheStage( )];
        Time.timeScale = worldTime;
    }
    public int NowtheStage() {
        Regex rex = new Regex(@"[^0-9]");
        int result = int.Parse(rex.Replace(SceneManager.GetActiveScene( ).name , ""));
        return result-1;
    }
}
