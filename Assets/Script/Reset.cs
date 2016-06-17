using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reset : MonoBehaviour {
    public void reset(string resetScene) {
        SceneManager.LoadScene(resetScene);
        GameObject.Find("UI/Return").GetComponent<Button>( ).interactable = false;
        CreateButton.moveflag = false;
        var turnDisplay=GameObject.Find("system").GetComponent<turndisplay>( );
        var create = GameObject.Find("system").GetComponent<CreateButton>( );
        turnDisplay.Dispose(create);
        if ( Physics.gravity.y > 0 ) {
            Physics.gravity = -Physics.gravity;
        }
    }
}
