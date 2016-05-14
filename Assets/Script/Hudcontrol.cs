using UnityEngine;
using System.Collections;
using UniRx.Triggers;
using UnityEngine.UI;
using UniRx;


public class Hudcontrol : MonoBehaviour {

    void Start() {
        
    }
    //                 追従させるオブジェクト
    public void Control(GameObject WorldObject) {

            RectTransform UI_Element = GameObject.Find("UI/Rotation").GetComponent<RectTransform>( );
            RectTransform CanvasRect = GameObject.Find("UI").GetComponent<RectTransform>( );

            Camera Cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>( );

            Vector2 ViewportPosition = Cam.WorldToViewportPoint(WorldObject.transform.position);
            Vector2 WorldObject_ScreenPosition = new Vector2(
                ( ( ViewportPosition.x * CanvasRect.sizeDelta.x ) - ( CanvasRect.sizeDelta.x * 0.5f ) ) ,
                ( ( ViewportPosition.y * CanvasRect.sizeDelta.y ) - ( CanvasRect.sizeDelta.y * 0.5f ) ));

            UI_Element.anchoredPosition = WorldObject_ScreenPosition;
    }
    //スクロールバーの可視化について
    public void Visibled(bool HudVisible=false) {
        var scrollbar=GameObject.Find("Rotation");
        scrollbar.GetComponent<Scrollbar>( ).interactable = HudVisible;
        scrollbar.GetComponent<Image>( ).enabled = HudVisible;
        GameObject.Find("Rotation/Sliding Area/Handle").GetComponent<Image>( ).enabled = HudVisible;        
    }
}
