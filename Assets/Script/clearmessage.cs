using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class clearmessage : dialog {
    private Text texts;

    void Start() {
        texts = GameObject.Find("clear/message").GetComponent<Text>( );
        this.GetComponent<Canvas>( ).enabled = false;
        Time.timeScale = 1;
    }
    public new void displaytext(string contents) {
        this.GetComponent<Canvas>( ).enabled = true;
        texts.text = contents;
    }
    public void reset() {
        SceneManager.LoadScene(StageManager.Instance.nowstage.Reset_Scene_Name);
        loadscene( );
    }
    public void loadscene() {
        SceneManager.LoadScene(StageManager.Instance.nowstage.Reset_Scene_Name);
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

