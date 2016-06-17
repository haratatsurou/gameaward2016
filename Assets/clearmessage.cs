using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class clearmessage : dialog {
    private Text text;
    
	void Start() {
        text = GameObject.Find("clear/message").GetComponent<Text>( );
        this.GetComponent<Canvas>( ).enabled = false;
        Time.timeScale = 1;
    }
    //public new void display(string contents) {

    //    base.display(contents);
    //}
    public new void displaytext(string contents) {
        this.GetComponent<Canvas>( ).enabled = true;
        text.text = contents;
    }
    public void loadscene(string resetScene ) {
        SceneManager.LoadScene(resetScene);
        GameObject.Find("clear").GetComponent<GraphicRaycaster>( ).enabled = false;
        CreateButton.moveflag = false;
        GameObject.Find("upgoal").GetComponent<Goal>( ).enabled = false;
        if ( Physics.gravity.y > 0 ) {
            Physics.gravity = -Physics.gravity;
        }
        var turnDisplay = GameObject.Find("UI/system").GetComponent<turndisplay>( );
        var create = GameObject.Find("UI/system").GetComponent<CreateButton>( );
        turnDisplay.Dispose(create);
    }
}

