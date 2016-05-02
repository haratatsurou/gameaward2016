using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class operation : MonoBehaviour{
    //public void OnBeginDrag(PointerEventData ped) {
    //    //GetComponent<BoxCollider>( ).enabled = false;
    //    this.gameObject.transform.position = fromScreenPostoWorldPos(ped);
    //}
    //public void OnDrag(PointerEventData ped) {
    //    this.gameObject.transform.position = fromScreenPostoWorldPos(ped);
    //}
    //public void OnEndDrag(PointerEventData ped) {

    //}
    //public void OnPointerClick(PointerEventData ped) {
    //    print("角度変える何か");
    //}
    //Vector2 fromScreenPostoWorldPos(PointerEventData ped) {
    //    Vector3 localpos = Vector3.zero;
    //    RectTransform setui = GameObject.Find("UI").GetComponent<RectTransform>( );
    //    RectTransformUtility.ScreenPointToWorldPointInRectangle(setui, ped.position , Camera.main , out localpos);
    //    Vector2 hoge = localpos;
    //    print(hoge);
    //    return hoge;
    //}
    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown() {
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x , Input.mousePosition.y , screenPoint.z));
        this.gameObject.GetComponent<BoxCollider>( ).isTrigger = true;
    }

    void OnMouseDrag() {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x , Input.mousePosition.y , screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        transform.position = currentPosition;
    }
    void OnMouseUp() {
        this.gameObject.GetComponent<BoxCollider>( ).isTrigger = false;

    }

}
