using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class clearmessage : dialog {
    public Sprite starSprite;
    private GameObject[] star=new GameObject[2];
    private Canvas canvas;
    void Start() {

        this.GetComponent<Canvas>( ).enabled = false;
        star = GameObject.FindGameObjectsWithTag("UIstar");
        //canvas= this.GetComponent<Canvas>( );
    }
    void Awake() {
        
    }
    //クリアしたときの情報を載せる
    public void displaytext() {
        Time.timeScale = 0;
       //canvas = this.GetComponent<Canvas>( );
        canvas = GameObject.Find("clear").GetComponent<Canvas>( );
        canvas.enabled = true;
        //texts.text = contents;
        StageManager.Instance.ClearInfo( );
        //取得したスターを表示-------------------------------
        for(int i=0 ;i<StageManager.Instance.nowstage.GetStar ;i++ ) {
            star[i].GetComponent<Image>( ).sprite = starSprite; //後ろから取り出す
            AudioManager.Instance.PlaySE("pointSE");
        }
    }
    public void reset() {
       
        //StageManager.Instance.nowstage.GetStar = 0;
        GameObject.Find("system").GetComponent<CreateButton>( ).ResetMatch( );
        loadscene( );
        Time.timeScale = 1;
        SceneManager.LoadScene(StageManager.Instance.nowstage.Reset_Scene_Name);
    }
    public void loadscene() {
        GameObject.Find("clear").GetComponent<GraphicRaycaster>( ).enabled = false;
        CreateButton.moveflag = false;
        GameObject.Find("upgoal").GetComponent<Goal>( ).enabled = false;
        if ( Physics.gravity.y > 0 ) {
            Physics.gravity = -Physics.gravity;
        }
        Physics.gravity = new Vector3(Physics.gravity.x , -9.81f , Physics.gravity.z);
        var turnDisplay = GameObject.Find("system").GetComponent<turndisplay>( );
        var create = GameObject.Find("system").GetComponent<CreateButton>( );
        turnDisplay.Dispose(create);
        Physics.gravity = new Vector3(0 , Physics.gravity.y , 0);
    }
    public void Next() {
        loadscene( );
        SceneManager.LoadScene(StageManager.Instance.nowstage.Next_Scene_Name);
        Time.timeScale = 1;
    }
}

