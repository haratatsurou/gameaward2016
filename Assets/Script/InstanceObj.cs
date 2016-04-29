using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InstanceObj : MonoBehaviour,IBeginDragHandler,IDragHandler ,IEndDragHandler{
    public GameObject insobj;
    private GameObject createobj;
	void Start () {
	
	}
	
	void Update () {
	
	}
    public void OnBeginDrag(PointerEventData obj) {
        Vector3 localpos = Vector3.zero;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(GetComponent<RectTransform>( ) , obj.position , Camera.main , out localpos);
        Vector2 hoge = localpos;
        createobj = Instantiate(insobj , hoge , insobj.transform.rotation) as GameObject;
    }
    public void OnDrag(PointerEventData obj) {
        Vector3 localpos = Vector3.zero;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(GetComponent<RectTransform>( ) , obj.position , Camera.main , out localpos);
        Vector2 hoge = localpos;
        createobj.transform.position = hoge ;
    }
    public void OnEndDrag(PointerEventData obj) {

    }

}
