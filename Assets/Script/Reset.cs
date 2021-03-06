﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reset : MonoBehaviour {
    public void reset() {
        SceneManager.LoadScene(StageManager.Instance.nowstage.Reset_Scene_Name);
        CreateButton.moveflag = false;
        var turnDisplay=GameObject.Find("system").GetComponent<turndisplay>( );
        var create = GameObject.Find("system").GetComponent<CreateButton>( );
        turnDisplay.Dispose(create);
        AudioManager.Instance.PlaySE("decideSE");
        if ( Physics.gravity.y > 0 ) {
            Physics.gravity = -Physics.gravity;
        }
        Physics.gravity = new Vector3(0 , Physics.gravity.y , 0);
        StageManager.Instance.nowstage.GetStar = 0;
        //設置フラグをすべてリセット
        this.GetComponent<CreateButton>( ).ResetMatch( );
    }

}
