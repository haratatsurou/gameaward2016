using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public struct info {
    public bool clear;
    public int getstar;

}

public class SaveManager : SavableSingleton<SaveManager> {
    public Dictionary<string,info> saveinfo=new Dictionary<string , info>();
    public info clearinfo=new info();
    public float volume;//音量
    public float speed;//世界スピード 

    //[HideInInspector]
    //public int oldstar;
    //public string oldsavedata;
    //void Start() {
    //    Load( );
    //    PlayerPrefs.DeleteAll();
    //    //for ( int i = 0 ; i < 3 ; i++ ) {
    //    //    print(CSVtoArray(LinkString( ))[i]);
    //    //}
    //    //PlayerPrefs.SetString("Result" , LinkString( ));
    //    //PlayerPrefs.Save( );
    //    AddDic(CSVtoArray(LinkString( )));
    //}
    //public void Save() {

    //}
    //public void Load() {
    //    oldsavedata = PlayerPrefs.GetString("Result");
    //}
    //public void Play() {
    //    oldstar = StageManager.Instance.nowstage.GetStar;
    //}
    ////Stage名＋クリアしたか＋最大の星の数をいい感じに連結する
    //public string LinkString() {
    //    string Linked = "Stage1,false,0,\n";
    //    var nowstage = StageManager.Instance.nowstage;
    //    if ( oldstar < nowstage.GetStar ) {
    //        Linked = nowstage.Reset_Scene_Name + ","
    //            + nowstage.Clear +","+ nowstage.GetStar+",\n";
    //    } else {
    //        Linked = nowstage.Reset_Scene_Name + ","
    //            + nowstage.Clear +","+ oldstar+",\n";
    //    }
    //    return oldsavedata+Linked;
    //}
    //info hoge = new info();
    //void AddDic(string[] data) {
    //    hoge.clear = Convert.ToBoolean(data[1]);
    //    hoge.getstar = int.Parse(data[2]);
    //    saveinfo.Add(data[0] , hoge);
    //    foreach ( KeyValuePair<string,info> key in saveinfo ) {
    //        print("key" + key.Key + "clear=" + key.Value.clear + "star=" + key.Value.getstar);
    //    }

    //}

    //string[] CSVtoArray(string word) {
    //    return word.Split(',');
    //}
}
