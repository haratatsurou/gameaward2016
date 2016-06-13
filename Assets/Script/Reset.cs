using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reset : MonoBehaviour {
    public void reset(string resetScene) {
        SceneManager.LoadScene(resetScene);
        GameObject.Find("Return").GetComponent<Button>( ).interactable = false;
        CreateButton.moveflag = false;
    }
}
