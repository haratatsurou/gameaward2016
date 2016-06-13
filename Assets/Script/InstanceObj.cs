using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InstanceObj : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public GameObject insobj;
    private GameObject createobj;
    public int setnum;
    void Start() {

    }

    public void OnBeginDrag(PointerEventData obj) {
        createobj = Instantiate(insobj , fromScreenPostoWorldPos(obj) , insobj.transform.rotation) as GameObject;
        createobj.name = this.gameObject.name;
        createobj.GetComponent<BoxCollider>( ).isTrigger = true;
        GameObject.Find("system").GetComponent<CreateButton>( ).set[setnum - 1] = true;
    }
    public void OnDrag(PointerEventData obj) {
        createobj.transform.position = fromScreenPostoWorldPos(obj);
    }
    public void OnEndDrag(PointerEventData obj) {
        //createobj.GetComponent<BoxCollider>( ).isTrigger = false;
        this.GetComponent<InstanceObj>( ).enabled = false;
        CreateButton.moveflag = false;
    }
    Vector2 fromScreenPostoWorldPos(PointerEventData ped) {
        Vector3 localpos = Vector3.zero;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(GetComponent<RectTransform>( ) , ped.position , Camera.main , out localpos);
        Vector2 hoge = localpos;
        return hoge;

    }

}
