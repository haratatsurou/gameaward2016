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
        Time.timeScale = 1;

    }
    public void display(string text) {
        this.GetComponent<Canvas>( ).enabled = true;
        Time.timeScale = 0;
        GameObject.Find("UI").GetComponent<GraphicRaycaster>( ).enabled = false;//playボタンとか押せないようにする
        displaytext(text);
    }
    public void returnGame() {
        this.GetComponent<Canvas>( ).enabled = false;
        Time.timeScale = 1;
    }
    public void displaytext(string contents) {
        text.text = contents;
    }
}
