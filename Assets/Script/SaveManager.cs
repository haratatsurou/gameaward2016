using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public struct info {
    public string StageName;
    public bool clear;
    public int getstar;

}

public class SaveManager : SingletonMonoBehaviour<SaveManager> {
    public List<info> saveinfo;
    public float volume;//音量
    public float speed;//世界スピード 

    [HideInInspector]
    public int oldstar;
    void Start() {
        for ( int i = 0 ; i <3 ; i++ ) {
            print(CSVtoArray(LinkString( ))[i]);
        }
        PlayerPrefs.SetString("Result",LinkString( ));
        PlayerPrefs.Save( );
    }
    public void Save() {

    }
    public void Load() {

    }
    public void Play() {
        oldstar = StageManager.Instance.nowstage.GetStar;
    }
    //Stage名＋クリアしたか＋最大の星の数をいい感じに連結する
    public string LinkString() {
        string Linked = "Stage1,false,0";
        var nowstage = StageManager.Instance.nowstage;
        if ( oldstar < nowstage.GetStar ) {
            Linked = nowstage.Reset_Scene_Name + ","
                + nowstage.Clear + nowstage.GetStar;
        } else {
            Linked = nowstage.Reset_Scene_Name + ","
                + nowstage.Clear +","+oldstar+"\n";
        }
        return Linked;
    }

    string[] CSVtoArray(string word) {
        return word.Split(',');
    }
}
