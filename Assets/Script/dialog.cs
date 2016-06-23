using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//お品書き
interface function {
    void display(string content);//dialogを表示させる
    void returnGame();// ボタンを押したらゲーム再開
    void displaytext(string content);//contentの内容を表示
}

//エラーMessageを出す奴
public class dialog : MonoBehaviour, function {
    private Text text;
    void Start() {
        text = GameObject.Find("dialog/message").GetComponent<Text>( );
        this.GetComponent<Canvas>( ).enabled = false;

    }
    //dialogを表示する
    public void display(string text) {
        this.GetComponent<Canvas>( ).enabled = true;
        Time.timeScale = 0;
        CreateButton.moveflag = true;
        GameObject.Find("UI").GetComponent<GraphicRaycaster>( ).enabled = false;//playボタンとか押せないようにする
        displaytext(text);
    }
    public void displaytext(string contents) {
        text.text = contents;
    }
    public void returnGame() {
        CreateButton.moveflag = false;
        this.GetComponent<Canvas>( ).enabled = false;
        GameObject.Find("UI").GetComponent<GraphicRaycaster>( ).enabled = true;
        Time.timeScale = StageManager.Instance.worldTime;
    }
}
