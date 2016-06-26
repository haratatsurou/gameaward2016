using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class clearmessage : dialog {
    private Text texts;
    public Sprite starSprite;
    private GameObject[] star=new GameObject[2];

    void Start() {
        texts = GameObject.Find("clear/message").GetComponent<Text>( );
        this.GetComponent<Canvas>( ).enabled = false;
        star = GameObject.FindGameObjectsWithTag("UIstar");
    }
    //クリアしたときの情報を載せる
    public new void displaytext(string contents) {
        this.GetComponent<Canvas>( ).enabled = true;
        texts.text = contents;
        StageManager.Instance.ClearInfo( );
        //取得したスターを表示-------------------------------
        for(int i=0 ;i<StageManager.Instance.nowstage.GetStar ;i++ ) {
            star[i].GetComponent<Image>( ).sprite = starSprite; //後ろから取り出す
        }
    }
    public void reset() {
        SceneManager.LoadScene(StageManager.Instance.nowstage.Reset_Scene_Name);
        StageManager.Instance.nowstage.GetStar = 0;
        GameObject.Find("system").GetComponent<CreateButton>( ).ResetMatch( );
        loadscene( );
    }
    public void loadscene() {
        GameObject.Find("clear").GetComponent<GraphicRaycaster>( ).enabled = false;
        CreateButton.moveflag = false;
        GameObject.Find("upgoal").GetComponent<Goal>( ).enabled = false;
        if ( Physics.gravity.y > 0 ) {
            Physics.gravity = -Physics.gravity;
        }
        var turnDisplay = GameObject.Find("system").GetComponent<turndisplay>( );
        var create = GameObject.Find("system").GetComponent<CreateButton>( );
        turnDisplay.Dispose(create);
        Physics.gravity = new Vector3(0 , Physics.gravity.y , 0);
    }
    public void Next() {
        SceneManager.LoadScene(StageManager.Instance.nowstage.Next_Scene_Name);
        loadscene( );
    }
}

